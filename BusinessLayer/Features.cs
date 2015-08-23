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
    public class Features
    {
        public ObjectId Id { get; set; }
        public string CarName { get; set; }
        public List<Feature> Options = new List<Feature>();

    }

    public class Feature
    {
        public String FeatureName { get; set; }
        public String FeatureDesc { get; set; }
    }
    
}
