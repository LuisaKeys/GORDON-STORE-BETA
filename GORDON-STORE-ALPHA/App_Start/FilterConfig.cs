using System.Web;
using System.Web.Mvc;

namespace GORDON_STORE_ALPHA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
