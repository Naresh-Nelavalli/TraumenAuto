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
    public class MongoCarFactsData : ICarFactsRepository
    {
              

       public CarFacts GetReport(string Vin)
        {
            string DbName = "CarFactsDB";
            ConnectedRepository fctx = new ConnectedRepository(DbName);
            QueryDocument FaxQuery = new QueryDocument();
            FaxQuery.Add("_id", Vin);
            CarFacts carFaxReport = fctx.CarFacts.FindOne(FaxQuery);
            return carFaxReport;
        }


    }
}
