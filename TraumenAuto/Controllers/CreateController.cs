using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using ManagerLayer;
using PagedList;
using TraumenAuto.Models;
using TraumenAuto.Factory;

namespace TraumenAuto.Controllers
{
    public class CreateController : Controller
    {

        private static readonly ICarRepository _carsdata = CarDataFactory.GetCarStoreType();
        static Dictionary<string, List<string>> carsListTempStore;
        // GET: Create
      
        [HttpGet]
        [ActionName("AddNewCar")]
        public ActionResult AddNewCar()
        {
            Dictionary<string, List<string>> carsList = _carsdata.GetCarModels();
            carsListTempStore = carsList;
            List<string> cm = new List<string>();
            foreach (string makerName in carsList.Keys)
            {
                cm.Add(makerName);
            }

            SelectList MakerName1 = new SelectList(cm);
            ViewData["MakerName"] = MakerName1;
            return View();
        }

        public JsonResult Models(string Maker)
        {
            List<string> ModelList = new List<string>();
            foreach (string tt1 in carsListTempStore.Keys)
            {
                if (tt1 == Maker)
                {
                    ModelList = carsListTempStore[tt1];

                }
            }

            return Json(ModelList);
        }


        [HttpPost]
        [ActionName("AddNewCar")]
        public ActionResult AddNewCar_Post()
        {
            Car carOne = new Car();
            TryUpdateModel(carOne);
            if (ModelState.IsValid)
            {
                UpdateModel(carOne);
                _carsdata.StoreCartoDb(carOne);
                return RedirectToAction("Cars","Cars");
            }
            return View();
        }
    }
}