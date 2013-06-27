using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SMP.Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            RegisterProcessoRoutes(routes);
            RegisterClienteRoutes(routes);
            RegisterRegistroRoute(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static void RegisterRegistroRoute(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Registros",
                url: "admin/clientes",
                defaults: new { controller = "Admin", action = "Registros" }
            );
        }

        private static void RegisterClienteRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Clientes",
                url: "admin/clientes",
                defaults: new { controller = "Admin", action = "Clientes" }
            );

            routes.MapRoute(
                name: "CriarCliente",
                url: "admin/cliente/criar",
                defaults: new { controller = "Admin", action = "CriarCliente" }
            );
        }

        private static void RegisterProcessoRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Processos",
                url: "admin/processos",
                defaults: new { controller = "Admin", action = "Processos" }
            );

            routes.MapRoute(
                name: "CriarProcesso",
                url: "admin/processo/criar",
                defaults: new { controller = "Admin", action = "CriarProcesso" }
            );

            routes.MapRoute(
                name: "RemoverProcesso",
                url: "admin/processo/remover",
                defaults: new { controller = "Admin", action = "RemoverProcesso" }
            );
        }
    }
}