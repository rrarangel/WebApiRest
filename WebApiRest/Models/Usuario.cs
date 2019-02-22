using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRest.Models
{
    public class Usuario
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string login { get; set; }

        public Usuario(int codigo, string nome, string login)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.login = login;
        }


    }
}