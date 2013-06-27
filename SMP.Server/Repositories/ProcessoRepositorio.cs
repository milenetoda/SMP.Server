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
    public class ProcessoRepositorio
    {
        private IOdb odb;

        public ProcessoRepositorio(IOdb odb)
        {
            this.odb = odb;
        }

        public List<Processo> Recuperar()
        {
            var processos = from processo in odb.AsQueryable<Processo>()
                            select processo;
            return processos.ToList();
        }

        public long Colocar(Processo processo)
        {
            return odb.Store(processo).ObjectId;
        }

        public void Remover(string nome)
        {
            var processos = from item in odb.AsQueryable<Processo>()
                            where item.Nome.Equals(nome)
                            select item;

            foreach (var item in processos)
                odb.Delete(item);
        }
    }
}