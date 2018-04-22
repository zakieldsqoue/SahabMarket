using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Util;
using DL.Model;
namespace BL.BLClass
{
   public class OrderBL
    {
        public void CreateOrder(Order _order)
        {
            new Order().CreateOrder(_order);
        }
    }
}
