using System.Web;
using System.Web.Mvc;
using SMP.Server.Filters;

namespace SMP.Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExportModelStateToTempData());
            filters.Add(new ImportModelStateFromTempData());
        }
    }
}