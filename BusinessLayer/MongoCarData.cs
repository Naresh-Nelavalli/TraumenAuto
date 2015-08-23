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
   
    public class MongoCarData:ICarRepository
    {
        string DbName = "CarDB";               
        //# Function to list of cars that are eligible for users request  
        public List<Car> GetCars(InputRequestAttributes RequestQuery)
        {
            
            //# Get the list of zipcodes that are located in specified distance from user requested zipcode
            ConnectedRepository ctx = new ConnectedRepository(DbName);
            LocationDataLayer lctx = new LocationDataLayer();
            List<string> NearByZipCodes = new List<string>();
            if (!string.IsNullOrEmpty(RequestQuery.Zipcode))
            {
                List<Location> locationsAround = lctx.GetNearZipcodes(RequestQuery.Zipcode,RequestQuery.distance);
                if (locationsAround.Count != 0)
                {
                    foreach (Location location in locationsAround)
                    {
                        NearByZipCodes.Add(location.zip);
                    }
                    NearByZipCodes.Add(RequestQuery.Zipcode);
                }
            }
            //# Build a DB query based on user constraint. Check request if it has value and add it to query.
            QueryDocument CarQuery = new QueryDocument();

            if (RequestQuery.Year > 2000)
                CarQuery.Add("Year", RequestQuery.Year);
            if (RequestQuery.Name != null)
                CarQuery.Add("Name", RequestQuery.Name);
            if (RequestQuery.Maker != null)
                CarQuery.Add("Maker", RequestQuery.Maker);
            if (RequestQuery.MaxPrice >= 1000)
                CarQuery.Add("Price", new BsonDocument("$lt", RequestQuery.MaxPrice));
            if (NearByZipCodes.Count() != 0)
                CarQuery.Add("Zipcode", new BsonDocument("$in", new BsonArray(NearByZipCodes)));
            MongoCursor<Car> Cars = ctx.Cars.Find(CarQuery);
            List<Car> carsList = Cars.ToList();
            return carsList;
         }
        
       
       public Car GetCarDetails(String Vin)
        {
            ConnectedRepository ctx = new ConnectedRepository(DbName);
            string carId = Vin;
            Car car = ctx.Cars.FindOneById(new ObjectId(carId));
            return car;
        }

        public Dictionary<string, List<string>> GetCarModels()
        {
            ConnectedRepository ctx = new ConnectedRepository(DbName);
            MongoCursor<Car> totalCars = ctx.Cars.FindAll();
            List<Car> carsList = totalCars.ToList();
            Dictionary<string, List<string>> carsByModel = OrganizeCarsByBrand(carsList);
            return carsByModel;
        }
        public void StoreCartoDb(Car newCarDetails)
        {
            ConnectedRepository ctx = new ConnectedRepository(DbName);
            ctx.Cars.Save(newCarDetails);
            
        }

               
        
        public Dictionary<string, List<string>> OrganizeCarsByBrand(List<Car> carsList)
       {
           Dictionary<string, List<string>> carsByModel = new Dictionary<string, List<string>>();

           foreach (Car tt in carsList)
           {
               if (tt.Maker != null)
               {
                   if (carsByModel.ContainsKey(tt.Maker))
                   {

                       List<string> temp = carsByModel[tt.Maker];
                       if (temp.Contains(tt.Name))
                       {
                           continue;
                       }
                       else
                       {
                           temp.Add(tt.Name);
                           carsByModel[tt.Maker] = temp;
                       }
                   }
                   else
                   {
                       List<string> temp = new List<string>();
                       temp.Add(tt.Name);
                       carsByModel.Add(tt.Maker, temp);
                   }
               }
               else
               {
                   continue;
               }
           }
           return carsByModel;
       }
    }

   }
