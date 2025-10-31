using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoReal
{
    class Program
    {
        static void Main(string[] args)
        {






        }

    }


    public class Banco 
    {
        public List<Cliente> listaClientes = new List<Cliente>();
        public List<Conta> listaContas = new List<Conta>();



        //Consultar saldo bancario
        //permitir fazer uma  transferencia 
        public void CadastrarCliente()
        {
            Console.WriteLine("Digite seu cpf: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Digite seu nome: ");
            string Nome = Console.ReadLine();

            Cliente cliente  = new Cliente(Cpf,Nome);
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
            if(valorDeposito > 0)
            {
                foreach(Conta conta in listaContas)
                            {
                                if(conta.numeroConta == numeroConta)
                                {
                                    conta.saldo += valorDeposito;
                                } 

                            }
                }
            else
            {
                Console.WriteLine("Valor de deposito inválido");
            }
           
         }

        public void Sacar(decimal valorSaque, string numeroConta)
        {
            if(valorSaque > 0)
            {
                foreach(Conta conta in listaContas)
                {
                    if(conta.numeroConta == numeroConta)
                    {
                        conta.saldo -= valorSaque;
                    }
                }
            }

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
      
        public ContaCorrente(string NumeroConta, decimal Saldo) : base (NumeroConta, Saldo)
        {


        }

    }

    public class ContaPoupanca : Conta
    {

        public ContaPoupanca(string NumeroConta, decimal Saldo, string Cpf) : base (NumeroConta, Saldo)
        {

        }

    }

    public class Cliente
    {


        //Cadastrar(cpf + nome)
        // Ter como abrir a conta
        // ter como acessar a conta
       
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



