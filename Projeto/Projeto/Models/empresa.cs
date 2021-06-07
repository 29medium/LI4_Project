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
    public class Empresa
    {
        public string empresaID{ get; set; }
        public string nome{ get; set; }
        public string categoria{ get; set; }
        public string website{get; set; }
        public string localizacao { get; set; }
        public string mercadoID{ get; set; }

        public Empresa() { }
        public Empresa(string eid, string nome, string cat, string website, string localizacao, string mid)
        {
            this.empresaID = eid;
            this.nome = nome;
            this.categoria = cat;
            this.website = website;
            this.localizacao = localizacao;
            this.mercadoID = mid;
        }
    }
}