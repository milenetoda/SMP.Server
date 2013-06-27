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
    public class ProcessoController : ApiController
    {   
        public List<Processo> Get()
        {
            ProcessoRepositorio repositorio = new ProcessoRepositorio(SessionManager.Open());
            return repositorio.Recuperar();
        }
    }
}
