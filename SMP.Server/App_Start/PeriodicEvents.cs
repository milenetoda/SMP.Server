using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Timers;
using System.Web;
using SMP.Server.Models;
using SMP.Server.Repositories;

namespace SMP.Server.App_Start
{
    public class PeriodicEvents
    {
        private static Timer timer;

        private static List<Cliente> clientes;
        
        public static void Setup()
        {
            timer = new Timer();
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Interval = 5 * 1000;
            timer.Elapsed += timer_Elapsed;
        }

        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (clientes == null) return;

            foreach (var client in clientes)
            {
                try
                {
                    Ping ping = new Ping();
                    var pingReply =  ping.Send(client.Ip);
                    client.Status = pingReply.Status.ToString();
                }
                catch  { }   
            }
        }
        
        public static void UpdateClientes()
        {
            ClienteRepositorio repositorio = new ClienteRepositorio(SessionManager.Open());
            clientes = repositorio.Recuperar();
        }

        public static List<Cliente> GetClientes()
        {
            return clientes;
        }
    }
}