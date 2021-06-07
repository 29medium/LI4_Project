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
        public double low{ get; set; }
        public double high { get; set; }
        public double avg { get; set; }
        public string empresaID{ get; set; }

        public Acao(){ }
        public Acao(string aid, DateTime hora, double low, double high, double avg, string eid)
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