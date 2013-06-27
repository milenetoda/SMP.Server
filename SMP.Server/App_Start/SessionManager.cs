using NDatabase;
using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SMP.Server.App_Start
{
    public class SessionManager
    {
        public static IOdb Open()
        {
            var session = HttpContext.Current.Items["OdbSession"] as IOdb;

            if (session == null) 
            {
                session = OdbFactory.Open(GetFilename());
                HttpContext.Current.Items.Add("OdbSession", session);
            }

            return session;
        }

        public static void Close()
        {
            var session = HttpContext.Current.Items["OdbSession"] as IOdb;

            if (session != null) 
            {
                if (!session.IsClosed()) 
                {
                    session.Dispose();
                }

                HttpContext.Current.Items.Remove("OdbSession");
            }
        }

        private static string _filename;

        private static string GetFilename()
        {
            if (_filename == null)
            {
                string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                _filename = Path.Combine(path, "BancoDeDados.db");
            }
            return _filename;
        }

    }
}