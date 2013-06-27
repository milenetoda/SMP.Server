using NDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMP.Server.App_Start;
using SMP.Server.Models;
using SMP.Server.Repositories;

namespace SMP.Server.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ClienteRepositorio clienteRepositorio;
        private ProcessoRepositorio processoRepositorio;
        private RegistroRepositorio registroRepositorio;
        
        public AdminController()
        {
            clienteRepositorio = new ClienteRepositorio(SessionManager.Open());
            processoRepositorio = new ProcessoRepositorio(SessionManager.Open());
            registroRepositorio = new RegistroRepositorio(SessionManager.Open());
        }

        #region Processos

        public ActionResult Processos()
        {
            return View(processoRepositorio.Recuperar());
        }

        [HttpPost]
        public ActionResult CriarProcesso(string nome)
        {
            Processo processo = new Processo(nome);

            processoRepositorio.Colocar(processo);

            return RedirectToAction("processos");
        }

        [HttpPost]
        public ActionResult RemoverProcesso(string nome)
        {
            processoRepositorio.Remover(nome);

            return RedirectToAction("processos");
        }

        #endregion

        #region Clientes

        public ActionResult Clientes()
        {
            PeriodicEvents.UpdateClientes();
            return View(clienteRepositorio.Recuperar());
        }

        [HttpPost]
        public ActionResult CriarCliente(string nome, string ip)
        {
            var cliente = new Cliente
            {
                Nome = nome,
                Ip = ip,
                Status = "-",
                UltimaAtualizacao = DateTime.Now
            };

            clienteRepositorio.Colocar(cliente);

            return RedirectToAction("clientes");
        }
        
        #endregion

        #region Registros

        public ActionResult Registros()
        {
            return View(registroRepositorio.Recuperar());
        }

        #endregion
    }
}
