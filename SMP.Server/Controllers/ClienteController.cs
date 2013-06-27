using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMP.Server.App_Start;
using SMP.Server.Models;
using SMP.Server.Repositories;

namespace SMP.Server.Controllers
{
    public class ClienteController : ApiController
    {
        public List<Cliente> Get()
        {
            return PeriodicEvents.GetClientes();
        }

        public void Delete(int id)
        {
            var repositorio = new ClienteRepositorio(SessionManager.Open());
            repositorio.Remover(id);
        }
    }
}
