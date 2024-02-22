using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_POO_16939_26052.Classes
{
    public class Servico
    {
        public string ServicoId { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }
        public string Descricao { get; set; }


        public Servico(string servicoId, string nome, string preco, string descricao)
        {
            ServicoId = servicoId;
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"ServicoId: {ServicoId}, Nome: {Nome}, Preco: {Preco}, Descricao: {Descricao}";
        }

        //registar novo Servico
        public static void RegistarNovoServico(List<Servico> listaServicos, string servicoId, string nome, 
            string preco, string descricao)
        {
            Servico novoServico = new Servico(servicoId, nome, preco, descricao);
            listaServicos.Add(novoServico);
            GuardaServico(listaServicos, "../../../Dados/dadosservico.csv");


            Console.WriteLine("Servico registado com sucesso!");
            Console.WriteLine("\n---------------------------------------------------\n");
        }


        //mostrar lista
        public static List<Servico> LerServicos(string filePath)
        {
            List<Servico> lerServicos = new List<Servico>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(',');
                string[] fields = new string[4];

                for (int i = 0; i < splitLine.Length && i < fields.Length; i++)
                {
                    fields[i] = splitLine[i];
                }

                string servicoId = fields[0];
                string nome = fields[1];
                string preco = fields[2];
                string descricao = fields[3];



                Servico servico = new Servico(servicoId, nome, preco, descricao);
                lerServicos.Add(servico);
            }

            return lerServicos;
        }

        //Guardar Servico
        public static void GuardaServico(List<Servico> listaServicos, string filePath)
        {
            using (StreamWriter sw5 = new StreamWriter(filePath, true))
            {
                foreach (Servico servico in listaServicos)
                {
                    sw5.WriteLine($"{servico.ServicoId},{servico.Nome},{servico.Preco},{servico.Descricao}\n");
                }
            }
        }

        public static bool EliminarServico(string nome)
        {
            List<Servico> listaServicos = LerServicos("../../../Dados/dadosservico.csv");

            foreach (var servico in listaServicos)
            {
                if (servico.Nome == nome)
                {
                    listaServicos.Remove(servico);
                    GuardaServico(listaServicos, "../../../Dados/dadosservico.csv");
                    return true;
                }
            }
            return false;
        }

    }

}
