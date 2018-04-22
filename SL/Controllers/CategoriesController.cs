using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using BL.BLClass;


namespace SL.Controllers
{
    public class CategoriesController : ApiController
    {
        CategoriesBL _categoriesBl = new CategoriesBL();
        // GET api/<controller>
        public List<object> Get()
        {
            return _categoriesBl.FindAll();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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