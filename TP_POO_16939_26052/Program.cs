using TP_POO_16939_26052;
using TP_POO_16939_26052.Classes;

class Program
{
    static void Main(string[] args)
    {
        List<Aluno> listaAlunos = new List<Aluno>();
        List<Senhorio> listaSenhorios = new List<Senhorio>();
        List<Admin> listaAdmins = new List<Admin>();


        bool continuarRegisto = true;

            while (continuarRegisto == true)
            {
                Menu.MenuPrincipal();

                Console.Write("Escolha uma opção: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.Clear();
                        Menu.MenuRegistarAluno(listaAlunos);
                        break;

                    case "2":
                        Console.Clear();
                        Menu.MenuAluno(listaAlunos);
                        break;

                    case "3":
                        Console.Clear();
                        Menu.MenuRegistarSenhorio(listaSenhorios);
                        break;

                    case "4":
                        Console.Clear();
                        Menu.MenuSenhorio(listaSenhorios);
                        break;
                    case "5":
                        Console.Clear();
                        Menu.MenuAdmin(listaAdmins);
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("--------------- RefreshMenu ---------------");

                        if (listaAlunos != null)
                        {
                            listaAlunos = Aluno.LerAlunos("../../../Dados/dadosaluno.csv");
                            Console.WriteLine("Lista de Alunos atualizada");
                        }
                        else
                        {
                            Console.WriteLine("ERRO! Lista de Alunos não atualizada   ");
                        }

                        if (listaSenhorios != null)
                        {
                            listaSenhorios = Senhorio.LerSenhorios("../../../Dados/dadossenhorio.csv");
                            Console.WriteLine("Lista de Senhorios atualizada");
                        }
                        else
                        {
                            Console.WriteLine("ERRO! Lista de Senhorios não atualizada   ");
                        }

                        if (listaAdmins != null)
                        {
                            listaAdmins = Admin.LerAdmins("../../../Dados/dadosadmin.csv");
                            Console.WriteLine("Lista de Admins atualizada");
                        }
                        else
                        {
                            Console.WriteLine("ERRO! Lista de Admins não atualizada   ");
                        }
                        Console.WriteLine("\n---------------------------------------------------\n");
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("--------------- Ajuda ---------------");
                        Console.WriteLine("Em caso de dúvida, contactar os serviços académicos");
                        break;

                    case "0":
                            continuarRegisto = false; //saida programa
                            Console.Clear();
                            Console.WriteLine("A sair do programa...");
                            return;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();

            }

    }
}

