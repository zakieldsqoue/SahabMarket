using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace BL.Util
{
   public class JsonOperations
    {
        public static string JsonSerialization(object o)
        {
            return JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.None,
                        new Newtonsoft.Json.JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                        });

        }
    }
}
