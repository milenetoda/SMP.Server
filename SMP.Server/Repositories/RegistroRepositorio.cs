using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMP.Server.Repositories
{
    public class RegistroRepositorio
    {
        private IOdb odb;

        public RegistroRepositorio(IOdb odb)
        {
            this.odb = odb;
        }

        public List<Registro> Recuperar()
        {
            var registros = from registro in odb.AsQueryable<Registro>()
                           select registro;

            return registros.ToList();
        }

        public long Colocar(Registro registro)
        {
            return odb.Store(registro).ObjectId;
        }
    }
}