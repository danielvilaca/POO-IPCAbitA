using System.Globalization;
using TP_POO_16939_26052.Classes;

namespace TP_POO_16939_26052
{
    public class Aluno : Pessoa
    {
        List<Aluno> listaAlunos = new List<Aluno>();

        private static int proximoAlunoId = 16000;

        public string AlunoId { get; set; }
        public string Curso { get; set; }
        public string Instituicao { get; set; }


        public Aluno(string alunoId, string nome, string dataNascimento, string email, string password, string curso, string instituicao) 
            : base(nome, dataNascimento, email, password)
        {
            AlunoId = alunoId;
            Nome = nome;
            DataNascimento = dataNascimento;
            Curso = curso;
            Email = email;
            Password = password;
            Instituicao = instituicao;
        }

        public override string ToString()
        {
            return $"{AlunoId},{Nome},{DataNascimento},{Curso},{Instituicao},{Email},{Password}";
        }

        //gerar id incrementável a partir de 16000 até 26999
        public static int GerarAlunoId()
        {
            int alunoId = proximoAlunoId; // Default ID is now proximoAlunoId
            if (File.ReadLines("../../../Dados/dadosaluno.csv").Any())
            {
                var lastLine = File.ReadLines("../../../Dados/dadosaluno.csv").Last();
                var lastAlunoId = int.Parse(lastLine.Split(',')[0]);
                alunoId = lastAlunoId + 1;
            }
            return alunoId;
        }

        //registar novo aluno
        public static void RegistarNovoAluno(List<Aluno> listaAlunos, string alunoId, string nome, string dataNascimento, 
            string curso, string instituicao, string email, string password)
        {
            Aluno novoAluno = new Aluno(alunoId, nome, dataNascimento, curso, instituicao, email, password);
            listaAlunos.Add(novoAluno);
            GuardaAluno(listaAlunos, "../../../Dados/dadosaluno.csv");

            Console.WriteLine("Aluno registado com sucesso!");
            Console.WriteLine("\n---------------------------------------------------\n");
        }

        //mostrar lista
        public static List<Aluno> LerAlunos(string filePath)
        {
            List<Aluno> alunos = new List<Aluno>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(',');
                string[] fields = new string[7];

                for (int i = 0; i < splitLine.Length && i < fields.Length; i++)
                {
                    fields[i] = splitLine[i];
                }

                string id = fields[0];
                string nome = fields[1];
                string dataNascimento = fields[2];
                string curso = fields[3];
                string instituicao = fields[4];
                string email = fields[5];
                string password = fields[6];

                Aluno aluno = new Aluno(id, nome, dataNascimento, curso, instituicao, email, password);
                alunos.Add(aluno);
            }

            return alunos;
        }


        public static void GuardaAluno(List<Aluno> listaAlunos, string filePath)
        {

            using (StreamWriter sw1 = new StreamWriter(filePath, true))
            {
                foreach (Aluno aluno in listaAlunos)
                {
                    sw1.WriteLine($"{aluno.AlunoId},{aluno.Nome},{aluno.DataNascimento},{aluno.Curso},{aluno.Instituicao}," +
                        $"{aluno.Email},{aluno.Password}\n");
                }
            }
        }

        //validar login pelo csv
        public static bool ValidarLoginAluno(string email, string password)
        {
            List<Aluno> listaAlunos = LerAlunos("../../../Dados/dadosaluno.csv");

            foreach (var aluno in listaAlunos)
            {
                if (aluno.Email == email && aluno.Password == password)
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

        public static bool EliminarAluno(string email)
        {
            List<Aluno> listaAlunos = LerAlunos("../../../Dados/dadosaluno.csv");

            foreach (var aluno in listaAlunos)
            {
                if (aluno.Email == email)
                {
                    listaAlunos.Remove(aluno);
                    GuardaAluno(listaAlunos, "../../../Dados/dadosaluno.csv");
                    return true;
                }
            }
            return false;
        }
    }
}
