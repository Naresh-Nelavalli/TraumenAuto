using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace DataLayer
{
    public class Car
    {

        public ObjectId Id      { get; set; }
        public string Name      { get; set; }
        public int Year         { get; set; }
        public string Maker     { get; set; }
        public int Odometer     { get; set; }
        public int Price        { get; set; }
        public double Mileage   { get; set; }
        public string StoreName { get; set; }
        public string Zipcode      { get; set; }
        public string Color     { get; set; }
        public CarTechDetails TechDetails = new CarTechDetails();  
    }

    public class CarTechDetails
    {
        public string EngineLine   { get; set; }
        public string Transmission { get; set; }
        public string FuelType     { get; set; }
        public string BodyStyle    { get; set; }
        public string DriveTrain   { get; set; }
        public int Doors           { get; set; }
    }
}
