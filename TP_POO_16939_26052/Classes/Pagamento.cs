using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_16939_26052.Classes;

namespace TP_POO_16939_26052
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Descricao { get; set; }

        // Constructor
        public Pagamento(int pagamentoId, decimal valor, DateTime dataPagamento, string descricao)
        {
            PagamentoId = pagamentoId;
            Valor = valor;
            DataPagamento = dataPagamento;
            Descricao = descricao;
        }
    }
}

