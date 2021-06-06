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
    public class Utilizador
    {
        public int userID{ get; set; }
        public string primeiroNome{ get; set; }
        public string ultimoNome{ get; set; }
        public string username{ get; set; }
        public string password{ get; set; }
        public string email{ get; set; }
        public int experiencia{ get; set; }
        public float capacidadeMonetaria{ get; set; }
        public string areaInteresse{ get; set; }
        public float coordX{ get; set; }
        public float coordY{ get; set; }

        public Utilizador() { }
        public Utilizador(int id,string pN,string uN,string username,string pass,string email,int exp, float capMon, string ai, float x, float y)
        {
            this.userID = id;
            this.primeiroNome = pN;
            this.ultimoNome = uN;
            this.username = username;
            this.password = pass;
            this.email = email;
            this.experiencia = exp;
            this.capacidadeMonetaria = capMon;
            this.areaInteresse = ai;
            this.coordX = x;
            this.coordY = y;
        }
    }
}