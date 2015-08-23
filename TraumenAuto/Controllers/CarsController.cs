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
    public class CarsController : Controller
    {
        private static readonly ICarRepository _carsdata = CarDataFactory.GetCarStoreType();
        private static readonly IFeatureRepository _featuredata = FeatureDataFactory.GetCarFeatureStoreType();
        private static readonly ICarFactsRepository _carfaxdata = CarFactsDataFactory.GetCarFactsStoreType();
        static Dictionary<string, List<string>> carsByModelsTempStore;
        // GET: Cars
        [HttpGet]
        public ActionResult Index()
        {
            Dictionary<string, List<string>> carMakerList = _carsdata.GetCarModels();
            carsByModelsTempStore = carMakerList;
            List<string> cm = new List<string>();
            cm.Add("All");
            foreach(string makerName in carMakerList.Keys)
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
            foreach (string makerName in carsByModelsTempStore.Keys)
            {
                if (makerName == Maker)
                {
                    ModelList = carsByModelsTempStore[makerName];
                    ModelList.Add("All");

                }
            }

            return Json(ModelList);
        }
        [HttpPost]
        public ActionResult Compare(List<string> CarId)
        {
            List<Car> CompareCars = new List<Car>();
            foreach( String carId in CarId)
            {
                Car car = _carsdata.GetCarDetails(carId);
                CompareCars.Add(car);
            }
            return View(CompareCars);
        }

                        
        public ActionResult Cars(string id, string name, string maker,string sortOrder,int price = 0,int distance = 50, int year = 0, string zipcode = "19333")
        {
            InputRequestAttributes Carreq = new InputRequestAttributes();
            Manager manager = new Manager();
                               
            // prepare the request object to send it to DAL. So DAL checks for the constraints that present in the Car object 
            // and prepares the dynamic DB query.
           
             Carreq.Zipcode = zipcode;
            if(maker!="All")
             Carreq.Maker = maker;
            if(name!="All")
             Carreq.Name = name;
            Carreq.MaxPrice = price;
            Carreq.Year = year;
            Carreq.distance = distance;
            List<Car> carsList = _carsdata.GetCars(Carreq);
            List<Car> SortedList = manager.SortCars(sortOrder,carsList);
            return View(SortedList);
        }
        [HttpGet]
        public ActionResult Details(String CarName, String Id)
        {
            Car car = _carsdata.GetCarDetails(Id);
            Features featuresList = _featuredata.GetFeature(CarName);
            List<Feature> options = featuresList.Options;
            return View(options);
        }
        [HttpGet]
        public ActionResult CarFax(String CarName, String Id)
        {
            Car car = _carsdata.GetCarDetails(Id);
            CarFacts carfactsDetails = _carfaxdata.GetReport(Id);
            Features featuresList = _featuredata.GetFeature(CarName);
            TotalCarDetailsVM vm = new TotalCarDetailsVM();
            vm.OneCarfacts = carfactsDetails;
            vm.OneCarData = car;
            vm.OneCarFeatures = featuresList;
            return View(vm);
        }
           
    }
}