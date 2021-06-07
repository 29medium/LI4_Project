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
    public class Acao
    {
        public string acaoID{ get; set; }
        public DateTime hora{ get; set; }
        public float low{ get; set; }
        public float high{ get; set; }
        public float avg{ get; set; }
        public string empresaID{ get; set; }

        public Acao(){ }
        public Acao(string aid, DateTime hora, float low, float high, float avg, string eid)
        {
            this.acaoID = aid;
            this.hora = hora;
            this.low = low;
            this.high = high;
            this.avg = avg;
            this.empresaID = eid;
        }
    }
}