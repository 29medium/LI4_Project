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

namespace SmartInvest.Models
{
    public class Empresa
    {
        public int empresaID{ get; set; }
        public string nome{ get; set; }
        public string categoria{ get; set; }
        public string website{get; set; }
        public float coordX{ get; set; }
        public float coordY{ get; set; }
        public int mercadoID{ get; set; }

        public Empresa() { }
        public Empresa(int eid, string nome, string cat, string website, float x, float y, int mid)
        {
            this.empresaID = eid;
            this.nome = nome;
            this.categoria = cat;
            this.website = website;
            this.coordX = x;
            this.coordY = y;
            this.mercadoID = mid;
        }
    }
}