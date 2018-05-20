using System.Web;
using System.Web.Mvc;
using DependencyInjectionWithLazy.Infrastructure;

namespace DependencyInjectionWithLazy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggerFilterAttribute());
        }
    }
}
