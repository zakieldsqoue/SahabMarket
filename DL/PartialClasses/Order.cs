using DL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Model
{
    public partial class Order
    {
        public void CreateOrder(Order _order)
        {
            _order.OrderDate = DateTime.Now;
            _order.OrderNum = GetCurrentOrderNumber();
       
            Global.Context.Order.Add(_order);
            var OrderList = _order.OrderItems.ToList();
            for (int i = 0; i < OrderList.Count(); i++)
            {
                OrderList[i].OrderID = _order.OrderID;
            }
            Global.Context.OrderItems.AddRange(OrderList);
            Global.Context.SaveChanges();
        }
        public long GetCurrentOrderNumber()
        {
            var LastNumber = (from a in Global.Context.Order orderby a.OrderNum descending select a.OrderNum).FirstOrDefault();
            return ( LastNumber + 1);
        }
    }
}
