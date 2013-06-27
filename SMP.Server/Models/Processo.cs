using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMP.Server.Models
{
    public class Processo
    {
        public Processo(string nome)
        {
            this.Nome = nome;
        }

        [OID]
        private readonly long id;
        public long Id
        {
            get { return id; }
        }

        public string Nome { get; set; }
    }
}