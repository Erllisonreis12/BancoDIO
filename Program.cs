using System;
using System.Collections.Generic;

namespace BancoDIO
{
    class Program
    {
        static List<Conta> listaConta = new List<Conta>();

        public static void  Main (string[] args) 
        {
            string opcao = ObterOpçaoUsuario();

            while (opcao.ToUpper()!="X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcao = ObterOpçaoUsuario();
            }
            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nossos serviços...");
            Console.ReadLine();
        }

        private static string ObterOpçaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("BANCO EQR - Aqui você pode confiar!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.Write("Opção: ");
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        public static void InserirContas()
        {
            Console.Clear();
            Console.WriteLine("Inserir Nova Conta");

            Console.Write("Digite o Nome do Títular: ");
            string nome = Console.ReadLine();

            Console.Write("Digite 1 para uma conta física ou 2 para uma conta jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Saldo Inicial em R$: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Crédito em R$: ");
            double credito = double.Parse(Console.ReadLine());

            Conta conta = new Conta((TipoConta)tipoConta, saldo, credito, nome);

            listaConta.Add(conta);
            Console.Clear();
            Console.WriteLine("Conta criada com Sucesso!!!");
            Console.WriteLine();
        }

        public static void ListarConta()
        {
            Console.Clear();
            if(listaConta.Count == 0) Console.WriteLine("Nenhuma Conta Cadastrada!!!");
            
            else
            {
                int i=0;
                foreach (var item in listaConta)
                {
                    Console.WriteLine("Numero da Conta: {0}", i);
                    Console.WriteLine(item.ToString());
                    Console.WriteLine();
                    i++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("voltar...");
            Console.ReadLine();
            Console.Clear();

        }

        public static void Sacar()
        {
            Console.Clear();
            Console.Write("Digite o numero da Conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
            
            Console.Clear();
            listaConta[numero].Sacar(valorSaque);

            Console.WriteLine();
            Console.WriteLine("voltar...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Depositar()
        {
            Console.Clear();
            Console.Write("Digite o numero da Conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            
            Console.Clear();
            listaConta[numero].Depositar(valorDeposito);

            Console.WriteLine();
            Console.WriteLine("voltar...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void Transferir()
        {
            Console.Clear();
            Console.Write("Digite o numero da Conta de Origem: ");
            int numeroOri = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da Conta de Destino: ");
            int numeroDes = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            
            Console.Clear();
            listaConta[numeroOri].Transferir(valorTransferencia, listaConta[numeroDes]);

            Console.WriteLine();
            Console.WriteLine("voltar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}