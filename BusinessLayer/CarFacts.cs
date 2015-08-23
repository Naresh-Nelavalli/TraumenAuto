using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace DataLayer
{
   public class CarFacts
    {   [BsonId]
        public string Vin             { get; set; }
        public bool AccidentReported    { get; set; }
        public double Odometer          { get; set; }
        public int YearofPurchase       { get; set; }
        public List<Owner> Owner = new List<Owner>();
    }

    public class Owner
    {
        public string OwnerType { get; set; }
        public string OwnerState  { get; set; }
        public DateTime PurchaseDate { get; set; }
        public List<MaintenanceData> Mdetails = new List<MaintenanceData>();
     }

    public class MaintenanceData
    {
        public double Mileage { get; set; }
        public DateTime Mdate { get; set; }
        public string Comments { get; set; }
        public string source { get; set; }
    }
}
