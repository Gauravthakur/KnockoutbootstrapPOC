using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnockoutBootStrap.Core;
using KnockoutBootStrap.Core.Services;

namespace KnockoutBootStrap.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Get()
        {
            KnockoutBootStrap.Core.Services.InventoryDataService obj = new InventoryDataService();
            var objInventory = obj.GetContractList();
            return Json(objInventory.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Post(KnockoutBootStrap.Core.ViewModels.InventoryViewModel newInventory)
        {
            if (newInventory.ItemName != null)
            {
                KnockoutBootStrap.Core.Services.InventoryDataService obj = new InventoryDataService();
                var dataitem = obj.SaveInventoryViewModel(newInventory);
                var objInventory = obj.GetContractList();
                return Json(objInventory.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("");

            }

        }
        [HttpPost]
        public ActionResult GetDatabyID(int id)
        {
            KnockoutBootStrap.Core.Services.InventoryDataService obj = new InventoryDataService();
            var dataitem = obj.GetInventoryViewModel(id);
            return Json(dataitem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            KnockoutBootStrap.Core.Services.InventoryDataService obj = new InventoryDataService();

            obj.DeleteInventory(id);
            var objInventory = obj.GetContractList();
            return Json(objInventory.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
    }
}