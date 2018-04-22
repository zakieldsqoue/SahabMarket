using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.BLClass;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class productsController : Controller
    {
        // GET: products
        public ActionResult Index(long CatID, string CatName)
        {
            
            ViewBag.Title = CatName;
            ViewBag.Items = new ItemBL().GetItemByCatID(CatID);
            return View();
        }
    }
}