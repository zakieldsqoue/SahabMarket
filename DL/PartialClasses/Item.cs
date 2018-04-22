using DL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Model
{
   
   public partial class Item:IData
    {
        public List<object> FindAll()
        {
            return (from a in Global.Context.Item select a).ToList<object>();
        }
        public List<Item> GetItemByCatID(long CatID)
        {
            return (from a in Global.Context.Item where a.CatID == CatID select a).ToList();
        }

    }
}
