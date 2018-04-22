using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        [Authorize(Roles = "Farms/Traders,Admin")]
         
        // GET: Items
        public ActionResult Index()
        {
           
            return View();
        }
       
    }
}