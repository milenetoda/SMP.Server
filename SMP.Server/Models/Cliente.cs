using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace SMP.Server.Models
{
    public class Cliente
    {
        [OID]
        private readonly long id;
        public long Id
        {
            get { return id; }
        }

        public string Nome { get; set; }
        public string Ip { get; set; }
        public string Status { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}