using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_POO_16939_26052.Classes;

namespace TP_POO_16939_26052.Classes
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsBlocked { get; set; }

        public Pessoa(string nome, string dataNascimento, string email, string password)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Password = password;
        }

    }
}
