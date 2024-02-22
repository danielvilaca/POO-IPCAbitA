using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TP_POO_16939_26052.Classes
{
    public class Menu
    {
        public static void MenuPrincipal()
        {
            Console.WriteLine("Bem-vindo ao IPCAbitA:");
            Console.WriteLine("1. Novo Aluno (Registar)");
            Console.WriteLine("2. Login Aluno");
            Console.WriteLine("3. Novo Senhorio (Registar)");
            Console.WriteLine("4. Login Senhorio");
            Console.WriteLine("5. Login Admin");
            Console.WriteLine("6. Refresh Menu");
            Console.WriteLine("7. Ajuda");
            Console.WriteLine("0. Sair");
        }


        //Menu Registar Aluno
        public static void MenuRegistarAluno(List<Aluno> listaAlunos)
        {
            //registar um novo aluno
            Console.WriteLine("--------------- Registar Novo Aluno ---------------");

            //alunoId
            string alunoId = "16000";


            //nome
            Console.Write("Nome: ");
            string nome = Console.ReadLine();


            //datanasc
            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            string dataNascimento = Console.ReadLine();

            Console.Write("Instituição Universitária: ");
            string instituicao = Console.ReadLine();


            Console.Write("Curso: ");
            string curso = Console.ReadLine();


            Console.Write("Email da Universidade: ");
            string email = Console.ReadLine();


            Console.Write("Password: ");
            string password = Console.ReadLine();


            Aluno.RegistarNovoAluno(listaAlunos, alunoId, nome, dataNascimento, curso, instituicao, email, password);
        }

        public static void DisplayMenuAluno()
        {
            Console.WriteLine("1 - Ver dados do Quarto");
            Console.WriteLine("2 - Ver Serviços");
            Console.WriteLine("3 - Contactar Senhorio");
            Console.WriteLine("4 - Contactar Admin");
            Console.WriteLine("5 - Eliminar Conta");
            Console.WriteLine("0 - Logout");
            Console.Write("Escolha uma opção: ");
            string? escolhaAluno = Console.ReadLine();

            switch (escolhaAluno)
            {
                case "1":
                    Console.Clear();
                    List<Quarto> quartos = Quarto.LerQuartos("../../../Dados/dadosquarto.csv");
                    foreach (Quarto quarto in quartos)
                    {
                        Console.WriteLine(quarto.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "2":
                    Console.Clear();
                    List<Servico> servicos = Servico.LerServicos("../../../Dados/dadosservico.csv");
                    foreach (Servico servico in servicos)
                    {
                        Console.WriteLine(servico.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Email do senhorio: ");
                    string emailSenhorio = Console.ReadLine();
                    Console.WriteLine("Mensagem: ");
                    string mensagemSenhorio = Console.ReadLine();
                    Console.WriteLine("Email enviado com sucesso!");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Email do admin: ");
                    string emailAdmin = Console.ReadLine();
                    Console.WriteLine("Mensagem: ");    
                    string mensagemAdmin = Console.ReadLine();
                    Console.WriteLine("Email enviado com sucesso!");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "5":
                    Console.Clear();
                    //Console.Write("Tem a certeza que pretende eliminar a sua conta? (sim/nao): ");
                    //string confirm = Console.ReadLine();
                    //if (confirm.ToLower() == "sim")
                    //{
                    //    bool successo = Aluno.EliminarAluno(loginAemail);
                    //    if (successo)
                    //    {
                    //        Console.WriteLine("\nConta eliminada com sucesso!");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("\nErro a eliminar a conta!");
                    //    }
                    //}
                    Console.WriteLine("Resolver");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "0":
                    Console.Clear();
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        public static void MenuAluno(List<Aluno> listaAlunos)
        {
            // Login como aluno
            Console.WriteLine("--------------- Login Aluno ---------------");

            Console.Write("Email: ");
            string loginAEmail = Console.ReadLine();

            Console.Write("Password: ");
            string loginAPass = Console.ReadLine();

            //verificar aluno
            bool validarAluno = Aluno.ValidarLoginAluno(loginAEmail, loginAPass);
            if (validarAluno)
            {
                Console.Clear();
                Console.WriteLine("Login bem-sucedido! Bem-vindo");
                Console.WriteLine("\n---------------------------------------------------\n");
                Menu.DisplayMenuAluno();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Falha no login. Verifique as suas credenciais.");
                Console.WriteLine("\n---------------------------------------------------\n");
            }
        }

        public static void DisplayMenuSenhorio()
        {
            Console.WriteLine("1 - Adicionar Quarto");
            Console.WriteLine("2 - Ver Quartos");
            Console.WriteLine("3 - Adicionar Serviço");
            Console.WriteLine("4 - Ver serviços");
            Console.WriteLine("5 - Contactar Aluno");
            Console.WriteLine("6 - Contactar Admin");
            Console.WriteLine("7 - Eliminar Conta");
            Console.WriteLine("0 - Logout");
            Console.Write("Escolha uma opção: ");
            string? escolhaAluno = Console.ReadLine();

            switch (escolhaAluno)
            {
                case "1":
                    Console.Clear();
                    List<Quarto> listaQuartos = new List<Quarto>();
                    MenuRegistarQuarto(listaQuartos);
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "2":
                    Console.Clear();
                    List<Quarto> quartos = Quarto.LerQuartos("../../../Dados/dadosquarto.csv");
                    foreach (Quarto quarto in quartos)
                    {
                        Console.WriteLine(quarto.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "3":
                    Console.Clear();
                    List<Servico> listaServicos = new List<Servico>();
                    MenuRegistarServico(listaServicos);
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "4":
                    Console.Clear();
                    List<Servico> servicos = Servico.LerServicos("../../../Dados/dadosservico.csv");
                    foreach (Servico servico in servicos)
                    {
                        Console.WriteLine(servico.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Email do aluno: ");
                    string emailAluno = Console.ReadLine();
                    Console.WriteLine("Mensagem: ");
                    string mensagemAluno = Console.ReadLine();
                    Console.WriteLine("Email enviado com sucesso!");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("Email do admin: ");
                    string emailAdmin = Console.ReadLine();
                    Console.WriteLine("Mensagem: ");
                    string mensagemAdmin = Console.ReadLine();
                    Console.WriteLine("Email enviado com sucesso!");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "7":
                    Console.Clear();
                    //Console.Write("Tem a certeza que pretende eliminar a sua conta? (sim/nao): ");
                    //string confirm = Console.ReadLine();
                    //if (confirm.ToLower() == "sim")
                    //{
                    //    bool successo = Senhorio.EliminarSenhorio(loginSemail);
                    //    if (successo)
                    //    {
                    //        Console.WriteLine("\nConta eliminada com sucesso!");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("\nErro a eliminar a conta!");
                    //    }
                    //}
                    Console.WriteLine("Resolver");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "0":
                    Console.Clear();
                    Console.WriteLine("A sair do programa...");
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;

            }
        }


        public static void MenuRegistarSenhorio(List<Senhorio> listaSenhorios)
        {
            //registar um novo senhorio
            Console.WriteLine("--------------- Registar Novo Senhorio ---------------");

            //nome
            Console.Write("Nome: ");
            string nomeSenhorio = Console.ReadLine();


            //datanasc
            Console.Write("Data de Nascimento (dd/MM/yyyy): ");
            string dataNascimentoSenhor = Console.ReadLine();


            Console.Write("Email: ");
            string emailSenhorio = Console.ReadLine();


            Console.Write("Password: ");
            string passwordSenhorio = Console.ReadLine();


            Senhorio.RegistarNovoSenhorio(listaSenhorios, nomeSenhorio, dataNascimentoSenhor, emailSenhorio, passwordSenhorio);
        }

        public static void MenuSenhorio(List<Senhorio> listaSenhorios)
        {
            //login como senhorio
            Console.WriteLine("--------------- Login Senhorio ---------------");
            Console.Write("Email: ");
            string loginSEmail = Console.ReadLine();

            Console.Write("Password: ");
            string loginSPass = Console.ReadLine();

            bool validarSenhorio = Senhorio.ValidarLoginSenhorio(loginSEmail, loginSPass);

            //verificar senhorio
            if (validarSenhorio)
            {
                Console.Clear();
                Console.WriteLine("Login bem-sucedido! Bem-vindo");
                Console.WriteLine("\n---------------------------------------------------\n");
                Menu.DisplayMenuSenhorio();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Falha no login. Verifique as suas credenciais.");
                Console.WriteLine("\n---------------------------------------------------\n");
            }
        }

        public static void MenuRegistarQuarto(List<Quarto> listaQuartos)
        {
            //registar um novo quarto
            Console.WriteLine("--------------- Registar Novo Quarto ---------------");

            string quartoId = "1";

            //nome
            Console.Write("Numero do Quarto: ");
            string numeroQuarto = Console.ReadLine();


            //datanasc
            Console.Write("Capacidade do Quarto: ");
            string capacidadeQuarto = Console.ReadLine();


            Console.Write("Breve Descricao do Quarto: ");
            string descricaoQuarto = Console.ReadLine();

            Quarto.RegistarNovoQuarto(listaQuartos, quartoId, numeroQuarto, capacidadeQuarto, descricaoQuarto);
        }

        public static void MenuRegistarServico(List<Servico> listaServicos)
        {
            //registar um novo servico
            Console.WriteLine("--------------- Registar Novo Serviço ---------------");

            string servicoId = "1";

            //nome
            Console.Write("Nome do Servico: ");
            string nome = Console.ReadLine();


            //datanasc
            Console.Write("Preço do Serviço: ");
            string preco = Console.ReadLine();


            Console.Write("Descricao do Serviço: ");
            string descricaoServico = Console.ReadLine();

            Servico.RegistarNovoServico(listaServicos, servicoId, nome, preco, descricaoServico);
        }




        public static void DisplayMenuAdmin()
        {
            Console.WriteLine("1 - Ver Alunos");
            Console.WriteLine("2 - Ver Senhorios");
            Console.WriteLine("3 - Ver Quartos");
            Console.WriteLine("4 - Ver Serviços");
            Console.WriteLine("5 - Eliminar Aluno");
            Console.WriteLine("6 - Eliminar Senhorio");
            Console.WriteLine("7 - Eliminar Quarto");
            Console.WriteLine("8 - Eliminar Serviço");
            Console.WriteLine("0 - Logout");
            Console.Write("Escolha uma opção: ");
            string? escolhaAluno = Console.ReadLine();

            switch (escolhaAluno)
            {
                case "1":
                    Console.Clear();
                    List<Aluno> alunos = Aluno.LerAlunos("../../../Dados/dadosaluno.csv");
                    foreach (Aluno aluno in alunos)
                    {
                        Console.WriteLine(aluno.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "2":
                    Console.Clear();
                    List<Senhorio> senhorios = Senhorio.LerSenhorios("../../../Dados/dadossenhorio.csv");
                    foreach (Senhorio senhorio in senhorios)
                    {
                        Console.WriteLine(senhorio.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "3":
                    Console.Clear();
                    List<Quarto> quartos = Quarto.LerQuartos("../../../Dados/dadosquarto.csv");
                    foreach (Quarto quarto in quartos)
                    {
                        Console.WriteLine(quarto.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;

                case "4":
                    Console.Clear();
                    List<Servico> servicos = Servico.LerServicos("../../../Dados/dadosservico.csv");
                    foreach (Servico servico in servicos)
                    {
                        Console.WriteLine(servico.ToString());
                    }
                    Console.WriteLine();
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;
                case "5":
                    Console.Clear();
                    //Console.Write("Email do aluno que pretende eliminar: ");
                    //string email = Console.ReadLine();
                    //bool successo = Aluno.EliminarAluno(email);
                    //if (successo)
                    //{
                    //    Console.WriteLine("Conta do aluno eliminada com sucesso!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Erro ao eliminar conta de aluno.");
                    //}
                    Console.WriteLine("Resolver");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;
                case "6":
                    Console.Clear();
                    //Console.Write("Email do senhorio que pretende eliminar: ");
                    //string email = Console.ReadLine();
                    //bool successo = Senhorio.EliminarSenhorio(email);
                    //if (successo)
                    //{
                    //    Console.WriteLine("Conta do senhorio eliminada com sucesso!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Erro ao eliminar conta de senhorio.");
                    //}
                    Console.WriteLine("Resolver");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;
                case "7":
                    Console.Clear();
                    //Console.Write("Numero do quarto que pretende eliminar: ");
                    //string numero = Console.ReadLine();
                    //bool successo = Quarto.EliminarQuarto(numero);
                    //if (successo)
                    //{
                    //    Console.WriteLine("Quarto eliminado com sucesso!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Erro ao eliminar quarto.");
                    //}
                    Console.WriteLine("Resolver");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;
                case "8":
                    Console.Clear();
                    //Console.Write("Nome do serviço que pretende eliminar: ");
                    //string nome = Console.ReadLine();
                    //bool successo = Servico.EliminarServico(nome);
                    //if (successo)
                    //{
                    //    Console.WriteLine("Serviço eliminado com sucesso!");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Erro ao eliminar serviço.");
                    //}
                    Console.WriteLine("Resolver");
                    Console.WriteLine("\n---------------------------------------------------\n");
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("A sair do programa...");
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;

            }
        }

        public static void MenuAdmin(List<Admin> listaAdmins)
        {
            //login como admin
            Console.WriteLine("--------------- Login Admin ---------------");
            Console.Write("Email: ");
            string loginEmail = Console.ReadLine();

            Console.Write("Password: ");
            string loginPass = Console.ReadLine();

            //procurar admin
            bool validarAdmin = Admin.ValidarLoginAdmin(loginEmail, loginPass);

            //verificar admin
            if (validarAdmin)
            {
                Console.Clear();
                Console.WriteLine("Login bem-sucedido! Bem-vindo");
                Console.WriteLine("\n---------------------------------------------------\n");
                Menu.DisplayMenuAdmin();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Falha no login. Verifique as suas credenciais.");
                Console.WriteLine("\n---------------------------------------------------\n");
            }
        }


    }
}
