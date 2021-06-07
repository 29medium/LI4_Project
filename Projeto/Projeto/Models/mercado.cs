using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading;

namespace Projeto.Models
{
    public class Mercado
    {
        public string mercadoID{ get; set; }
        public string pais{ get; set; }
        public string nome{ get; set; }

        public Mercado (){  }
        public Mercado (string mid, string pais, string nome)
        {
            this.mercadoID = mid;
            this.pais = pais;
            this.nome = nome;
        }
    }
}
