using NDatabase;
using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SMP.Server.Models;

namespace SMP.Server.Repositories
{
    public class ClienteRepositorio
    {
        private IOdb odb;

        public ClienteRepositorio(IOdb odb)
        {
            this.odb = odb;
        }

        public List<Cliente> Recuperar()
        {
            var clientes = from cliente in odb.AsQueryable<Cliente>()
                           select cliente;

            return clientes.ToList();
        }

        public long Colocar(Cliente cliente)
        {
            return odb.Store(cliente).ObjectId;
        }

        public void Remover(long id)
        {
            var clientes = from item in odb.AsQueryable<Cliente>()
                            where item.Id.Equals(id)
                            select item;

            foreach (var item in clientes)
                odb.Delete(item);
        }
    }
}