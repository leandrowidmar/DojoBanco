using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoReal
{
    class App
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o sistema bancário...");

            Banco meuBanco = new Banco();

            while (true)
            {
                Console.WriteLine("\n1 - Cadastro do cliente");
                Console.WriteLine("2 - Cadastrar conta corrente");
                Console.WriteLine("3 - Cadastrar conta poupança");
                Console.WriteLine("4 - Efetuar depósito");
                Console.WriteLine("5 - Efetuar saque");
                Console.WriteLine("6 - Consultar saldo");
                Console.WriteLine("7 - Efetuar transferência");
                Console.WriteLine("S - Sair");
                Console.Write("Selecione a ação: ");
                string opcao = Console.ReadLine().ToUpper();

                if (opcao == "S")
                    break;

                switch (opcao)
                {
                    case "1":
                        meuBanco.CadastrarCliente();

                        break;

                    case "2":
                        Console.WriteLine("Digite o CPF do cliente para que a conta seja criada: ");
                        string cpfContaCoerrente = Console.ReadLine();

                        Console.WriteLine("Digite o número da nova conta (ex: 1001-5): ");
                        string numeroContaCorrente = Console.ReadLine();

                        Console.WriteLine("Digite o saldo inicial (ex: 50,00): ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal valorSaldoCorrente))
                        {
                            Cliente clienteEncontrado = null;

                            foreach (Cliente cliente in meuBanco.listaClientes)
                            {
                                if (cliente.Cpf == cpfContaCoerrente)
                                {
                                    clienteEncontrado = cliente;
                                    break;
                                }
                            }

                            if (clienteEncontrado != null)
                            {
                                meuBanco.CriarContaCorrente(clienteEncontrado, numeroContaCorrente, valorSaldoCorrente);

                                Console.WriteLine("Conta corrente criada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Erro: Cliente não encontrado. Cadastre o cliente primeiro (Opção 1).");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor de saldo inválido. Use apenas números (ex: 50,00).");
                        }
                        break;

                    case "3":
                        //   meuBanco.CriarContaPoupanca();
                        Console.WriteLine("Digite o CPF do cliente para que a conta seja criada: ");
                        string cpfContaPoupanca = Console.ReadLine();

                        Console.WriteLine("Digite o número da nova conta (ex: 1001-5): ");
                        string numeroContaPoupanca = Console.ReadLine();

                        Console.WriteLine("Digite o saldo inicial (ex: 50,00): ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal valorSaldoPoupanca))
                        {
                            Cliente clienteEncontrado = null;

                            foreach (Cliente cliente in meuBanco.listaClientes)
                            {
                                if (cliente.Cpf == cpfContaPoupanca)
                                {
                                    clienteEncontrado = cliente;
                                    break;
                                }
                            }

                            if (clienteEncontrado != null)
                            {
                                meuBanco.CriarContaPoupanca(clienteEncontrado, numeroContaPoupanca, valorSaldoPoupanca);

                                Console.WriteLine("Conta Poupança criada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Erro: Cliente não encontrado. Cadastre o cliente primeiro (Opção 1).");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor de saldo inválido. Use apenas números (ex: 50,00).");
                        }
                        break;

                    case "4":    //    meuBanco.Depositar();
                        Console.WriteLine("Digite o número da conta para o depósito: ");
                        string numeroContaDeposito = Console.ReadLine();

                        Console.WriteLine("Digite o valor que deseja depositar: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal valorDeposito))
                        {
                            meuBanco.Depositar(valorDeposito, numeroContaDeposito);

                            Console.WriteLine("O depósito foi realizado!!!!");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido. Por favor, digite apenas números (ex: 50,00).");
                        }
                        break;

                    case "5":  // sacar                   
                        Console.WriteLine("Digite o número da conta para o saque: ");
                        string numeroContaSacar = Console.ReadLine();

                        Console.WriteLine("Digite o valor que deseja sacar: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal valorSaque))
                        {
                            meuBanco.Sacar(valorSaque, numeroContaSacar);

                        }
                        else
                        {
                            Console.WriteLine("Valor inválido. Por favor, digite apenas números (ex: 50,00).");
                        }
                        break;

                    case "6":
                        //  meuBanco.ConsultarSaldo();
                        Console.WriteLine("Digite o número da sua conta: ");
                        string numeroConta = Console.ReadLine();
                        meuBanco.ConsultarSaldo(numeroConta);
                        break;

                    case "7":
                        //  meuBanco.Transferencia();
                        Console.WriteLine("Digite o número da sua conta: ");
                        string contaOrigem = Console.ReadLine();

                        Console.WriteLine("Digite o número conta que deseja fazer a trasferencia: ");
                        string contaDestinatario = Console.ReadLine();

                        Console.WriteLine("Digite o valor que deseja fazer a transferencia (EX: 50,00): ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal valorTransferencia))
                        {
                            Console.WriteLine("O valor é valido!!!");
                            meuBanco.Transferencia(valorTransferencia, contaOrigem, contaDestinatario);

                        }
                        else
                        {
                            Console.WriteLine("Tranferencia invalida!!! valor ou conta inválida!!!");
                        }
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");

                        break;
                }
            }
            Console.WriteLine("\nEncerrando o sistema bancário...");
        }

    }


    public class Banco
    {
        public List<Cliente> listaClientes = new List<Cliente>();
        public List<Conta> listaContas = new List<Conta>();

        public void CadastrarCliente()
        {
            Console.WriteLine("Digite seu cpf: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Digite seu nome: ");
            string Nome = Console.ReadLine();

            Cliente cliente = new Cliente(Cpf, Nome);
            listaClientes.Add(cliente);
        }

        public void CriarContaCorrente(Cliente cliente, string numeroConta, decimal saldo)
        {
            ContaCorrente contaCorrente = new ContaCorrente(numeroConta, saldo);
            cliente.listaContas.Add(contaCorrente);
            listaContas.Add(contaCorrente);
        }

        public void CriarContaPoupanca(Cliente cliente, string numeroConta, decimal saldo)
        {
            ContaPoupanca contaPoupanca = new ContaPoupanca(numeroConta, saldo);
            cliente.listaContas.Add(contaPoupanca);
            listaContas.Add(contaPoupanca);
        }


        public void Depositar(decimal valorDeposito, string numeroConta)
        {
            if (valorDeposito > 0)
            {
                foreach (Conta conta in listaContas)
                {
                    if (conta.numeroConta == numeroConta)
                    {
                        conta.saldo += valorDeposito;
                    }

                }
            }
            else
            {
                Console.WriteLine("Valor de deposito inválido, conta não encontrada!");
            }

        }

        public void Sacar(decimal valorSaque, string numeroConta)
        {
            if (valorSaque <= 0)
            {
                Console.WriteLine("Valor de saque inválido. O valor deve ser positivo.");
                return;
            }


            Conta contaParaSacar = null;

            foreach (Conta conta in listaContas)
            {
                if (conta.numeroConta == numeroConta)
                {
                    contaParaSacar = conta;
                    break;
                }
            }

            if (contaParaSacar == null)
            {
                Console.WriteLine("Erro: Conta não encontrada.");
                return; // Para o método aqui
            }

            if (contaParaSacar.saldo >= valorSaque)
            {
                contaParaSacar.saldo -= valorSaque;
                Console.WriteLine($"Saque de {valorSaque} realizado com sucesso.");
                Console.WriteLine($"Novo saldo: {contaParaSacar.saldo}");
            }
            else
            {

                Console.WriteLine("Saldo insuficiente para este saque.");
                Console.WriteLine($"Valor solicitado: {valorSaque}");
                Console.WriteLine($"Saldo disponível: {contaParaSacar.saldo}");
            }
        }


        public void ConsultarSaldo(string numeroConta)
        {
            foreach (Conta conta in listaContas)
            {
                if (conta.numeroConta == numeroConta)
                {
                    Console.WriteLine($"O saldo da sua conta é:{conta.saldo}");
                    return;
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                }
            }
        }

        public void Transferencia(decimal valorTransferencia, string numeroContaOrigem, string numeroContaDestino)
        {


            Conta contaOrigem = null;
            Conta contaDestino = null;
            foreach (Conta conta in listaContas)
            {
                if (conta.numeroConta == numeroContaOrigem)
                {
                    contaOrigem = conta;
                }
                if (conta.numeroConta == numeroContaDestino)
                {
                    contaDestino = conta;
                }
            }

            if (valorTransferencia <= 0)
            {
                Console.WriteLine("Erro na transferência: O valor deve ser positivo.");
                return;
            }


            if (contaOrigem == null)
            {
                Console.WriteLine("Erro na transferência: Conta de origem não encontrada.");
                return; 
            }

            if (contaDestino == null)
            {
                Console.WriteLine("Erro na transferência: Conta de destino não encontrada.");
                return; 
            }

            if (contaOrigem == contaDestino) 
            {
                Console.WriteLine("Erro: Não é possível transferir para a mesma conta, escolha a opção depósito!");
                return;
            }

            if (contaOrigem.saldo < valorTransferencia)
            {
                Console.WriteLine("Erro na transferência: Saldo insuficiente!");
                Console.WriteLine($"Saldo disponível: {contaOrigem.saldo}");
                return;
            }

            contaOrigem.saldo -= valorTransferencia;
            contaDestino.saldo += valorTransferencia;

            Console.WriteLine("\nTransferência realizada com sucesso!");
            Console.WriteLine($"Novo saldo da conta de origem: {contaOrigem.numeroConta} saldo: {contaOrigem.saldo}");
        }


        }

        public class Conta
        {
            public string numeroConta;
            public decimal saldo;

            public Conta(string NumeroConta, decimal Saldo)
            {
                numeroConta = NumeroConta;
                saldo = Saldo;

            }
        }

        public class ContaCorrente : Conta
        {

            public ContaCorrente(string NumeroConta, decimal Saldo) : base(NumeroConta, Saldo)
            {

            }

        }

        public class ContaPoupanca : Conta
        {

            public ContaPoupanca(string NumeroConta, decimal Saldo) : base(NumeroConta, Saldo)
            {

            }

        }

        public class Cliente
        {
            public string Cpf { get; set; }
            public string Nome { get; set; }
            public List<Conta> listaContas = new List<Conta>();

            public Cliente(string cpf, string nome)
            {
                Cpf = cpf;
                Nome = nome;
            }

            public void AbrirContaCorrente(string numeroConta, decimal saldo)
            {
                ContaCorrente contaCorrenteAbrir = new ContaCorrente(numeroConta, saldo);
                listaContas.Add(contaCorrenteAbrir);
            }

        }

    }



