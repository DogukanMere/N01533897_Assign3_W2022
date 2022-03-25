using System.Web;
using System.Web.Mvc;

namespace N01533897_Assign3_W2022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
