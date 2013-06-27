using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SMP.Server.App_Start;
using SMP.Server.Repositories;

namespace SMP.Server.Controllers
{
    public class RegistroController : ApiController
    {
        public void Post(Registro registro)
        {
            var repositorio = new RegistroRepositorio(SessionManager.Open());
            repositorio.Colocar(registro);
        }
    }
}
