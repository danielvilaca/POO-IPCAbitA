using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TP_POO_16939_26052.Classes;

namespace TP_POO_16939_26052
{
    public class Quarto
    {
        List<Quarto> listaQuartos = new List<Quarto>();

        public string QuartoId { get; set; }
        public string Numero { get; set; }
        public string Capacidade { get; set; }
        public string Descricao { get; set; }


        public Quarto(string quartoId, string numero, string capacidade, string descricao)
        {
            QuartoId = quartoId;
            Numero = numero;
            Capacidade = capacidade;
            Descricao = descricao;
        }

        public override string ToString()
    {
        return $"QuartoId: {QuartoId}, Numero: {Numero}, Capacidade: {Capacidade}, Descricao: {Descricao}";
    }

        //registar novo Quarto
        public static void RegistarNovoQuarto(List<Quarto> listaQuartos, string quartoId, string numero,
            string capacidade, string descricao)
        {
            Quarto novoQuarto = new Quarto(quartoId, numero, capacidade, descricao);
            listaQuartos.Add(novoQuarto);
            GuardaQuarto(listaQuartos, "../../../Dados/dadosquarto.csv");


            Console.WriteLine("Quarto registado com sucesso!");
            Console.WriteLine("\n---------------------------------------------------\n");
        }


        //mostrar lista
        public static List<Quarto> LerQuartos(string filePath)
        {
            List<Quarto> lerQuartos = new List<Quarto>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(',');
                string[] fields = new string[4];

                for (int i = 0; i < splitLine.Length && i < fields.Length; i++)
                {
                    fields[i] = splitLine[i];
                }

                string quartoId = fields[0];
                string numero = fields[1];
                string capacidade = fields[2];
                string descricao = fields[3];



                Quarto quarto = new Quarto(quartoId, numero, capacidade, descricao);
                lerQuartos.Add(quarto);
            }

            return lerQuartos;
        }

        public static void GuardaQuarto(List<Quarto> listaQuartos, string filePath)
        {
            using (StreamWriter sw4 = new StreamWriter(filePath, true))
            {
                foreach (Quarto quarto in listaQuartos)
                {
                    sw4.WriteLine($"{quarto.QuartoId},{quarto.Numero},{quarto.Capacidade},{quarto.Descricao}\n");
                }
            }
        }


        public static bool EliminarQuarto(string numero)
        {
            List<Quarto> listaQuartos = LerQuartos("../../../Dados/dadosquarto.csv");

            foreach (var quarto in listaQuartos)
            {
                if (quarto.Numero == numero)
                {
                    listaQuartos.Remove(quarto);
                    GuardaQuarto(listaQuartos, "../../../Dados/dadosquarto.csv");
                    return true;
                }
            }
            return false;
        }

    }

}
