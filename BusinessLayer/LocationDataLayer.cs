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
    class LocationDataLayer
    {
        private MongoDatabase db1;
        public LocationDataLayer()
        {
            MongoClient client1 = new MongoClient();
            var server1 = client1.GetServer();
            this.db1 = server1.GetDatabase("geospatial");
            var collection = db1.GetCollection<Location>("zips1");
        }

        public MongoCollection<Location> zips
        {
            get
            {
                return db1.GetCollection<Location>("zips1");
            }
        }

        public List<Location> GetNearZipcodes(string zip, int distance)
        {
            LocationDataLayer lctx = new LocationDataLayer();
            QueryDocument ZipQuery = new QueryDocument();
            ZipQuery.Add("zip", zip);
            double distance1 = distance * (1/69.0);
            Location GeoLocation = lctx.zips.FindOne(ZipQuery);
            if (GeoLocation != null)
            {
                var query = Query.Near("loc", GeoLocation.loc.lat, GeoLocation.loc.lon, distance1);
                MongoCursor<Location> Zips = zips.Find(query);
                List<Location> NearbyZips = Zips.ToList();
                return NearbyZips;
            }
            else
            {
                // need to handle Exception in much better way 
                return null;
            }
                        
        }
    }
}
