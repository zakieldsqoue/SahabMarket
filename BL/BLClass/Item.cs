using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Model;
namespace BL.BLClass
{
   public class ItemBL
    {
        Item _Item = new Item();
        public List<Item> GetItemByCatID(long CatID)
        {
            return _Item.GetItemByCatID(CatID);
        }
        public List<object> FindAll()
        {
            return _Item.FindAll();
        }
    }
}
