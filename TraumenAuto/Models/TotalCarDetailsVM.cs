using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TraumenAuto.Models
{
    public class TotalCarDetailsVM
    {
        public CarFacts OneCarfacts { get; set; }
        public Car OneCarData { get; set; }
        public Features OneCarFeatures { get; set; }
        public List<Car> allCars { get; set; }
        public List<Feature> allFeatures { get; set; }
        public List<Owner> allOwners { get; set; }
        public List<MaintenanceData> allData { get; set; }
        
    }
}
