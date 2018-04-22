using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.BLClass;
using DL.Model;
using SL.Util;
using BL.Util;
namespace SL.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(Order _order)
        {
            new OrderBL().CreateOrder(_order);
            new SendMail().SendAsync(new Message() {Destination=new UsersBL().GetEmailByName(_order.UserName),Subject="New Order",MessageContent="New order created with order number #"+ _order.OrderNum+"created in  date:"+ _order.OrderDate });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}