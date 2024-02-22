using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_16939_26052.Classes;

namespace TP_POO_16939_26052
{
    public class Senhorio : Pessoa
    {
        List<Senhorio> listaSenhorios = new List<Senhorio>();

        public Senhorio(string nome, string dataNascimento, string email, string password) 
            : base(nome, dataNascimento, email, password)
        {
            
        }

        public override string ToString()
        {
            return $"{Nome},{DataNascimento},{Email},{Password}";
        }

        //registar novo senhorio
        public static void RegistarNovoSenhorio(List<Senhorio> listaSenhorios, string nome, string dataNascimento, 
            string email, string password)
        {
            Senhorio novoSenhorio = new Senhorio(nome, dataNascimento, email, password);
            listaSenhorios.Add(novoSenhorio);
            GuardaSenhorio(listaSenhorios, "../../../Dados/dadossenhorio.csv");


            Console.WriteLine("Senhorio registado com sucesso!");
            Console.WriteLine("\n---------------------------------------------------\n");
        }

        //mostrar lista
        public static List<Senhorio> LerSenhorios(string filePath)
        {
            List<Senhorio> lerSenhorios = new List<Senhorio>();

            string[] lines = File.ReadAllLines(filePath);

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
                

                Senhorio senhorio = new Senhorio(nome, dataNascimento, email, password);
                lerSenhorios.Add(senhorio);
            }

            return lerSenhorios;
        }

        public static void GuardaSenhorio(List<Senhorio> listaSenhorios, string filePath)
        {
            using (StreamWriter sw2 = new StreamWriter(filePath, true))
            {
                foreach (Senhorio senhorio in listaSenhorios)
                {
                    sw2.WriteLine($"{senhorio.Nome},{senhorio.DataNascimento},{senhorio.Email},{senhorio.Password}\n");
                }
            }
        }

        //validar login do Senhorio
        public static bool ValidarLoginSenhorio(string email, string password)
        {
            List<Senhorio> listaSenhorios = LerSenhorios("../../../Dados/dadossenhorio.csv");

            foreach (var senhorio in listaSenhorios)
            {
                if (senhorio.Email == email && senhorio.Password == password)
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

        public static bool EliminarSenhorio(string email)
        {
            string filePath = "../../../Dados/dadossenhorio.csv";
            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            // Find the line with the user's email
            int lineIndex = lines.FindIndex(line => line.Split(',')[0] == email);

            // If the line was found, remove it
            if (lineIndex != -1)
            {
                lines.RemoveAt(lineIndex);
                File.WriteAllLines(filePath, lines);
                return true;
            }

            return false;
        }

    }
}
