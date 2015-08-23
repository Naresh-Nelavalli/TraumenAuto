using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataLayer
{
    //[BsonIgnoreExtraElements]
    public class Location
    {

        public ObjectId id { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public loc loc { get; set; }
        public int pop { get; set; }
        public string state { get; set; }
    }
    public class loc
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }


}
