using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace WinTuner.Services.Diagnosticos
{
    public class VerificarRedeService
    {
        public async Task<ResultadoRede> DiagnosticarAsync(
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            NetworkInterface? interfaceRede =
                ObterInterfacePrincipal();

            if (interfaceRede == null)
            {
                return new ResultadoRede
                {
                    RedeFuncionando = false,
                    StatusConexao = "Desconectado",
                    NomeAdaptador = "Nenhum adaptador conectado",
                    Velocidade = "-",
                    MacAddress = "-",
                    IPv4 = "-",
                    IPv6 = "-",
                    Gateway = "-",
                    Dns = "-",
                    TesteGateway = new TesteRede
                    {
                        Sucesso = false,
                        Mensagem = "Nenhum adaptador de rede ativo foi encontrado."
                    },
                    TesteInternet = new TesteRede
                    {
                        Sucesso = false,
                        Mensagem = "Sem conexão de rede."
                    },
                    TesteDns = new TesteRede
                    {
                        Sucesso = false,
                        Mensagem = "Sem conexão de rede."
                    }
                };
            }

            cancellationToken.ThrowIfCancellationRequested();

            IPInterfaceProperties propriedades =
                interfaceRede.GetIPProperties();

            string ipv4 = ObterIPv4(propriedades);
            string ipv6 = ObterIPv6(propriedades);
            string gateway = ObterGateway(propriedades);
            string dns = ObterDns(propriedades);

            string velocidade = ObterVelocidade(
                interfaceRede.Speed
            );

            string mac = ObterMacAddress(
                interfaceRede.GetPhysicalAddress()
            );

            string statusConexao =
                interfaceRede.OperationalStatus ==
                OperationalStatus.Up
                    ? "Conectado"
                    : "Desconectado";

            cancellationToken.ThrowIfCancellationRequested();

            TesteRede testeGateway =
                await TestarGatewayAsync(
                    propriedades,
                    cancellationToken
                );

            cancellationToken.ThrowIfCancellationRequested();

            TesteRede testeInternet =
                await TestarInternetAsync(
                    cancellationToken
                );

            cancellationToken.ThrowIfCancellationRequested();

            TesteRede testeDns =
                await TestarDnsAsync(
                    cancellationToken
                );

            bool redeFuncionando =
                interfaceRede.OperationalStatus ==
                OperationalStatus.Up &&
                testeInternet.Sucesso &&
                testeDns.Sucesso;

            return new ResultadoRede
            {
                RedeFuncionando = redeFuncionando,

                StatusConexao = statusConexao,

                NomeAdaptador =
                    interfaceRede.Name,

                Velocidade = velocidade,

                MacAddress = mac,

                IPv4 = ipv4,

                IPv6 = ipv6,

                Gateway = gateway,

                Dns = dns,

                TesteGateway = testeGateway,

                TesteInternet = testeInternet,

                TesteDns = testeDns
            };
        }

        private NetworkInterface? ObterInterfacePrincipal()
        {
            NetworkInterface[] interfaces =
                NetworkInterface.GetAllNetworkInterfaces();

            NetworkInterface? melhorInterface = null;

            foreach (NetworkInterface rede in interfaces)
            {
                if (rede.NetworkInterfaceType ==
                    NetworkInterfaceType.Loopback)
                {
                    continue;
                }

                if (rede.NetworkInterfaceType ==
                    NetworkInterfaceType.Tunnel)
                {
                    continue;
                }

                if (rede.OperationalStatus !=
                    OperationalStatus.Up)
                {
                    continue;
                }

                IPInterfaceProperties propriedades;

                try
                {
                    propriedades = rede.GetIPProperties();
                }
                catch
                {
                    continue;
                }

                bool possuiIPv4 =
                    propriedades.UnicastAddresses
                        .Any(x =>
                            x.Address.AddressFamily ==
                            AddressFamily.InterNetwork);

                if (!possuiIPv4)
                    continue;

                bool possuiGateway =
                    propriedades.GatewayAddresses
                        .Any(x =>
                            x.Address.AddressFamily ==
                            AddressFamily.InterNetwork);

                if (possuiGateway)
                {
                    return rede;
                }

                melhorInterface ??= rede;
            }

            return melhorInterface;
        }

        private string ObterIPv4(
            IPInterfaceProperties propriedades)
        {
            IPAddress? endereco =
                propriedades.UnicastAddresses
                    .Select(x => x.Address)
                    .FirstOrDefault(x =>
                        x.AddressFamily ==
                        AddressFamily.InterNetwork &&
                        !IPAddress.IsLoopback(x));

            return endereco?.ToString() ?? "-";
        }

        private string ObterIPv6(
            IPInterfaceProperties propriedades)
        {
            IPAddress? endereco =
                propriedades.UnicastAddresses
                    .Select(x => x.Address)
                    .FirstOrDefault(x =>
                        x.AddressFamily ==
                        AddressFamily.InterNetworkV6 &&
                        !x.IsIPv6LinkLocal);

            return endereco?.ToString() ?? "-";
        }

        private string ObterGateway(
            IPInterfaceProperties propriedades)
        {
            IPAddress? gateway =
                propriedades.GatewayAddresses
                    .Select(x => x.Address)
                    .FirstOrDefault(x =>
                        x.AddressFamily ==
                        AddressFamily.InterNetwork);

            return gateway?.ToString() ?? "-";
        }

        private string ObterDns(
            IPInterfaceProperties propriedades)
        {
            List<string> servidores =
                propriedades.DnsAddresses
                    .Where(x =>
                        x.AddressFamily ==
                        AddressFamily.InterNetwork ||
                        x.AddressFamily ==
                        AddressFamily.InterNetworkV6)
                    .Select(x => x.ToString())
                    .Distinct()
                    .ToList();

            if (servidores.Count == 0)
                return "-";

            return string.Join(", ", servidores);
        }

        private string ObterMacAddress(
            PhysicalAddress endereco)
        {
            byte[] bytes =
                endereco.GetAddressBytes();

            if (bytes.Length == 0)
                return "-";

            return string.Join(
                ":",
                bytes.Select(x => x.ToString("X2"))
            );
        }

        private string ObterVelocidade(long velocidade)
        {
            if (velocidade <= 0)
                return "-";

            double megabits =
                velocidade / 1_000_000.0;

            if (megabits >= 1000)
            {
                return $"{megabits / 1000:0.##} Gbps";
            }

            return $"{megabits:0.##} Mbps";
        }

        private async Task<TesteRede> TestarGatewayAsync(
            IPInterfaceProperties propriedades,
            CancellationToken cancellationToken)
        {
            IPAddress? gateway =
                propriedades.GatewayAddresses
                    .Select(x => x.Address)
                    .FirstOrDefault(x =>
                        x.AddressFamily ==
                        AddressFamily.InterNetwork);

            if (gateway == null)
            {
                return new TesteRede
                {
                    Sucesso = false,
                    Mensagem = "Gateway não configurado."
                };
            }

            return await ExecutarPingAsync(
                gateway.ToString(),
                "Gateway",
                cancellationToken
            );
        }

        private async Task<TesteRede> TestarInternetAsync(
            CancellationToken cancellationToken)
        {
            return await ExecutarPingAsync(
                "1.1.1.1",
                "Internet",
                cancellationToken
            );
        }

        private async Task<TesteRede> TestarDnsAsync(
            CancellationToken cancellationToken)
        {
            Stopwatch stopwatch =
                Stopwatch.StartNew();

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                IPHostEntry resultado =
                    await Dns.GetHostEntryAsync(
                        "www.microsoft.com",
                        cancellationToken
                    );

                stopwatch.Stop();

                bool encontrouEndereco =
                    resultado.AddressList.Length > 0;

                if (!encontrouEndereco)
                {
                    return new TesteRede
                    {
                        Sucesso = false,
                        Mensagem = "DNS não retornou endereço.",
                        TempoMs = stopwatch.ElapsedMilliseconds
                    };
                }

                return new TesteRede
                {
                    Sucesso = true,
                    Mensagem =
                        $"Resolução OK ({stopwatch.ElapsedMilliseconds} ms)",
                    TempoMs = stopwatch.ElapsedMilliseconds
                };
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (SocketException ex)
            {
                stopwatch.Stop();

                return new TesteRede
                {
                    Sucesso = false,
                    Mensagem =
                        $"Falha na resolução DNS: {ex.Message}",
                    TempoMs = stopwatch.ElapsedMilliseconds
                };
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                return new TesteRede
                {
                    Sucesso = false,
                    Mensagem = ex.Message,
                    TempoMs = stopwatch.ElapsedMilliseconds
                };
            }
        }

        private async Task<TesteRede> ExecutarPingAsync(
            string endereco,
            string nomeTeste,
            CancellationToken cancellationToken)
        {
            Stopwatch stopwatch =
                Stopwatch.StartNew();

            using Ping ping = new Ping();

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                PingReply resposta =
                    await ping.SendPingAsync(
                        endereco,
                        3000
                    );

                stopwatch.Stop();

                if (resposta.Status ==
                    IPStatus.Success)
                {
                    return new TesteRede
                    {
                        Sucesso = true,
                        Mensagem =
                            $"{resposta.RoundtripTime} ms",
                        TempoMs =
                            resposta.RoundtripTime
                    };
                }

                return new TesteRede
                {
                    Sucesso = false,
                    Mensagem =
                        $"{nomeTeste}: {ObterDescricaoStatusPing(resposta.Status)}",
                    TempoMs =
                        stopwatch.ElapsedMilliseconds
                };
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (PingException ex)
            {
                stopwatch.Stop();

                return new TesteRede
                {
                    Sucesso = false,
                    Mensagem =
                        $"{nomeTeste}: {ex.InnerException?.Message ?? ex.Message}",
                    TempoMs =
                        stopwatch.ElapsedMilliseconds
                };
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                return new TesteRede
                {
                    Sucesso = false,
                    Mensagem = ex.Message,
                    TempoMs =
                        stopwatch.ElapsedMilliseconds
                };
            }
        }

        private string ObterDescricaoStatusPing(
            IPStatus status)
        {
            return status switch
            {
                IPStatus.TimedOut =>
                    "Tempo limite excedido",

                IPStatus.DestinationHostUnreachable =>
                    "Destino inacessível",

                IPStatus.DestinationNetworkUnreachable =>
                    "Rede de destino inacessível",

                IPStatus.DestinationUnreachable =>
                    "Destino inacessível",

                _ =>
                    status.ToString()
            };
        }
    }

    public class ResultadoRede
    {
        public bool RedeFuncionando { get; set; }

        public string StatusConexao { get; set; }
            = string.Empty;

        public string NomeAdaptador { get; set; }
            = string.Empty;

        public string Velocidade { get; set; }
            = string.Empty;

        public string MacAddress { get; set; }
            = string.Empty;

        public string IPv4 { get; set; }
            = string.Empty;

        public string IPv6 { get; set; }
            = string.Empty;

        public string Gateway { get; set; }
            = string.Empty;

        public string Dns { get; set; }
            = string.Empty;

        public TesteRede TesteGateway { get; set; }
            = new();

        public TesteRede TesteInternet { get; set; }
            = new();

        public TesteRede TesteDns { get; set; }
            = new();
    }

    public class TesteRede
    {
        public bool Sucesso { get; set; }

        public string Mensagem { get; set; }
            = string.Empty;

        public long TempoMs { get; set; }
    }
}