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
    public class MongoFeatureData : IFeatureRepository
    {
       

        public  Features GetFeature(string carName)
        {
            string DbName = "CarFeaturesDB";
            ConnectedRepository fctx = new ConnectedRepository(DbName);
            QueryDocument FeatureQuery = new QueryDocument();
            FeatureQuery.Add("CarName", carName);
            Features featuresOfCar = fctx.Features.FindOne(FeatureQuery);
            if (featuresOfCar != null)
                return featuresOfCar;
            else
                return null;
        }


    }
}
