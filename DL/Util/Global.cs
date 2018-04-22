using DL.Model;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Web;

namespace DL.Util
{
    public sealed class Global
    {
        public static TaskDBEntities Context
        {
            get
            {
                string ocKey = "key_" + HttpContext.Current.GetHashCode().ToString("x");  // key_2cf9b11
                if (!HttpContext.Current.Items.Contains(ocKey))
                    HttpContext.Current.Items.Add(ocKey, new TaskDBEntities());
                return HttpContext.Current.Items[ocKey] as TaskDBEntities;
            }
        }



        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["HousingSystemConnectionString"].ToString();
            }
        }


    }
}
