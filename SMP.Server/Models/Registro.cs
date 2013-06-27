using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMP.Server
{
    public class Registro
    {
        [OID]
        private readonly long id;
        public long Id
        {
            get { return id; }
        }

        public string Ip{ get; set; }
        public string Processo { get; set; }
        public DateTime Data { get; set; }

    }
}
