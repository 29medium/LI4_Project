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
        public string localizacao { get; set; }

        public Utilizador() { }
        public Utilizador(int id,string pN,string uN,string username,string pass,string email,int exp, float capMon, string localizacao)
        {
            this.userID = id;
            this.primeiroNome = pN;
            this.ultimoNome = uN;
            this.username = username;
            this.password = pass;
            this.email = email;
            this.experiencia = exp;
            this.capacidadeMonetaria = capMon;
            this.localizacao = localizacao;
        }

        private static string GetMd5Hash(MD5 md5Hash,string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static String HashPassword(string password)
        {
            using(MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, password);
                return hash;
            }
        }
    }

    public class CreateModel
    {
        [Required]
        [Display(Name = "username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "primeiroNome")]
        public string PrimeiroNome { get; set; }

        [Required]
        [Display(Name = "ultimoNome")]
        public string UltimoNome { get; set; }

        [Required]
        [Display(Name = "experiencia")]
        public int Experiencia { get; set; }

        [Required]
        [Display(Name = "capacidadeMonetaria")]
        public float CapacidadeMonetaria { get; set; }

        [Required]
        [Display(Name = "localizacao")]
        public string Localizacao { get; set; }

    }

    public class LogInModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}