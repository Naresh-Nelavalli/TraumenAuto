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
using System.Web.Configuration;


namespace DataLayer
{
    class ConnectedRepository
    {

        private MongoDatabase db;

        //## Constrcutor to create MongoDB Connnection 
        public ConnectedRepository(string DBname)
        {
            MongoClient client = new MongoClient();
            var server = client.GetServer();
            string DBname1 = WebConfigurationManager.AppSettings[DBname];
            this.db = server.GetDatabase(DBname1);
        }

       /* public void Connect(string DBname)
        {
            MongoClient client = new MongoClient();
            var server = client.GetServer();
            string DBname1 = WebConfigurationManager.AppSettings[DBname];
            this.db = server.GetDatabase(DBname1);
        }*/

        public MongoCollection<Car> Cars
        {
            get
            {
                return db.GetCollection<Car>(WebConfigurationManager.AppSettings["CarsCollection"].ToString());
            }

        }

        public MongoCollection<CarFacts> CarFacts
        {
            get
            {
                return db.GetCollection<CarFacts>(WebConfigurationManager.AppSettings["CarsFactsCollection"].ToString());
            }

        }

        public MongoCollection<Features> Features
        {
            get
            {
                return db.GetCollection<Features>(WebConfigurationManager.AppSettings["CarFeaturesCollection"].ToString());
            }

        }
    }

}
