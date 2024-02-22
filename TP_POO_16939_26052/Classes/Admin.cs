using System.Globalization;
using TP_POO_16939_26052.Classes;

namespace TP_POO_16939_26052
{
    public class Admin : Pessoa
    {
        private static int proximoAdminId = 1;
        public int AdminId { get; private set; }


        private Admin(string nome, string dataNascimento, string email, string password) : 
            base(nome, dataNascimento, email, password)
        {
            AdminId = GerarAdminId();
        }

        //gerar id incrementável
        private int GerarAdminId()
        {
            int novoAdminId = proximoAdminId;
            proximoAdminId++;

            return novoAdminId;
        }

        //registar novo admin
        public static void RegistarNovoAdmin(List<Admin> listaAdmins, string nome, string dataNascimento, string email, string password)
        {
            Admin novoAdmin = new Admin(nome, dataNascimento, email, password);
            listaAdmins.Add(novoAdmin);
            GuardaAdmin(listaAdmins, "../../../Dados/dadosadmin.csv");

            Console.WriteLine("Admin registado com sucesso!");
            Console.WriteLine("\n---------------------------------------------------\n");
        }

        //mostrar lista
        public static List<Admin> LerAdmins(string fileName)
        {
            List<Admin> lerAdmins = new List<Admin>();

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(',');
                string[] fields = new string[4];

                for (int i = 0; i < splitLine.Length && i < fields.Length; i++)
                {
                    fields[i] = splitLine[i];
                }

                string nome = fields[0];
                string dataNascimento = fields[1];
                string email = fields[2];
                string password = fields[3];

                Admin admin = new Admin(nome, dataNascimento, email, password);
                lerAdmins.Add(admin);
            }

            return lerAdmins;
        }

        //guardar dados do admin
        public static void GuardaAdmin(List<Admin> listaAdmins, string fileName)
        {
            using (StreamWriter sw3 = new StreamWriter(fileName, true))
            {
                foreach (Admin admin in listaAdmins)
                {
                    sw3.WriteLine($"{admin.Nome},{admin.DataNascimento},{admin.Email},{admin.Password}\n");
                }
            }
        }

        //validar login do Admin
        public static bool ValidarLoginAdmin(string email, string password)
        {
            List<Admin> listaAdmins = LerAdmins("../../../Dados/dadosadmin.csv");

            foreach (var admin in listaAdmins)
            {
                if (admin.Email == email && admin.Password == password)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Erro: Email ou Password incorretos. Tente novamente.");
                }
            }

            return false;
        }

    }
}
