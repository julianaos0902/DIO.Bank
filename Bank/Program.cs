using System;
using System.Collections.Generic;
namespace Bank
{
    class Bank
    {
        static void Main()
        {
            
            List<Conta> listaContas = new();
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas(listaContas);
                        break;
                    case "2":
                        listaContas = InserirConta(listaContas);
                        break;
                    case "3":
                        Transferir(listaContas);
                        break;
                    case "4":
                        Sacar(listaContas);
                        break;
                    case "5":
                        Depositar(listaContas);
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();                        
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();


        }

        private static void Transferir(List<Conta> listaContas)
        {
            Console.WriteLine("Digite o número da conta de origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido:");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);

        }

        private static void Depositar(List<Conta> listaContas)
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do depósito:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);


        }

        private static void Sacar(List<Conta> listaContas)
        {
            Console.WriteLine("Digite o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque:");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);



        }

        private static void ListarContas(List<Conta> listaContas)
        {
            int i = 0;
            Console.WriteLine("Listar contas");

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            foreach (Conta contas in listaContas)
            {
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(contas);
                i++;
            }
            
        }

        private static List<Conta> InserirConta(List<Conta> listaContas)
        {
            
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Digite 1 para Conta Física ou 2 para Juridica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new (tipoConta: (TipoConta)entradaTipoConta,
                                        nome: entradaNome,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito);
           
            listaContas.Add(novaConta);
            return listaContas;

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO BANK a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
