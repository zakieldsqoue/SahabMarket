using DL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Model
{
    public partial class Categories:IData
    {
        public List<object> FindAll()
        {
            return (from a in Global.Context.Categories select a).ToList<object>();
        }


    }


}
