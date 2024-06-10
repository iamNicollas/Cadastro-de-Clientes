using System;
using System.Collections.Generic;

class Program
{
    static List<dadosCliente> lstClientes = new List<dadosCliente>();

    public static void Main(string[] args)
    {
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\nSelecione uma opção: \n");
            Console.WriteLine("1 - Adicionar cliente");
            Console.WriteLine("2 - Visualizar clientes");
            Console.WriteLine("3 - Editar cliente");
            Console.WriteLine("4 - Excluir cliente");
            Console.WriteLine("5 - Sair \n");

            Console.WriteLine("opção escolhida: ");
            int opcao = Convert.ToInt32(Console.ReadLine());
            switch (opcao)
            {

                case 1:
                    AdicionarCliente();
                    break;

                case 2:
                    VisualizarClientes();
                    break;

                case 3:
                    EditarCliente();
                    break;

                case 4:
                    ExcluirCliente();
                    break;

                case 5:
                    executando = false;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nSaindo do programa...");
                    Console.ResetColor();
                    break;

                default:
                    Console.WriteLine("\nOpção inválida");
                    break;
            }
        }
    }


    public static void AdicionarCliente()
    {
        Console.WriteLine("\nDigite o Nome do cliente:");
        string nome = Console.ReadLine();

        Console.WriteLine("\nDigite o Email do cliente:");
        string email = Console.ReadLine();

        dadosCliente client = new dadosCliente(nome, email);
        lstClientes.Add(client);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nCliente adicionado com sucesso.");
        Console.ResetColor();
    }

    public static void VisualizarClientes()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n---------LISTA--------");
        Console.ResetColor();

        foreach (dadosCliente dados in lstClientes)
        {
            Console.WriteLine("Nome: " + dados.strNome);
            Console.WriteLine("Email: " + dados.strEmail);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------");
            Console.ResetColor();
        }
    }

    public static void EditarCliente()
    {
        Console.WriteLine("\nDigite o nome do Cliente que deseja editar: ");
        string nome = Console.ReadLine();

        dadosCliente client = lstClientes.Find(x => x.strNome == nome);

        if (client != null)
        {
            Console.WriteLine("\nDados atuais do cliente: ");

            Console.WriteLine("\nNome: " + client.strNome);
            Console.WriteLine("Email: " + client.strEmail);
            Console.WriteLine("----------------------");

            Console.WriteLine("\nAltere o Nome do Cliente: ");
            string novoNome = Console.ReadLine();

            Console.WriteLine("\nAlterar Email do Cliente: ");
            string novoEmail = Console.ReadLine();

            client.strNome = novoNome;
            client.strEmail = novoEmail;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDados alterados com sucesso.");
            Console.ResetColor();
        }

        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCliente não encontrado.");
            Console.ResetColor();
        }
    }

    public static void ExcluirCliente()
    {
        Console.WriteLine("\nDigite o nome do cliente que deseja excluir: ");
        string nome = Console.ReadLine();

        dadosCliente client = lstClientes.Find(x => x.strNome == nome);
        if (client != null)
        {
            Console.WriteLine("\nDeseja Excluir os dados do seguinte Cliente:");
            Console.WriteLine("Nome: " + client.strNome);
            Console.WriteLine("Email: " + client.strEmail);
            Console.WriteLine("----------------------");
            Console.WriteLine("1 - Sim | 2 - Não");

            Console.WriteLine("\nopção escolhida: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1)
            {
                lstClientes.Remove(client);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCliente excluído com sucesso.");
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOperação cancelada.");
                Console.ResetColor();
            }
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCliente não encontrado.");
            Console.ResetColor();
        }
    }
}

class dadosCliente
{
    public string strNome { get; set; }
    public string strEmail { get; set; }

    public dadosCliente(string nome, string email)
    {
        strNome = nome;
        strEmail = email;
    }
}