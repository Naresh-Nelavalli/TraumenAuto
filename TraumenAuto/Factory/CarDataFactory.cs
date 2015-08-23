using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Web.Configuration;

namespace TraumenAuto.Factory
{
    public class CarDataFactory
    {


        public static ICarRepository GetCarStoreType()
        {
            // Read DBConnName From Web Config File 
            string DBConnObject = WebConfigurationManager.AppSettings["CarData"];
            
            if (DBConnObject != null)
            {
                
                var handle = Activator.CreateInstance("DataLayer", DBConnObject);
                var Obj = handle.Unwrap();
                ICarRepository RepositoryTypeObject;
                RepositoryTypeObject = (ICarRepository)Obj;
                return RepositoryTypeObject;
            }
            else
            {
                Console.WriteLine(" Invalid Database Found. Fetching Data from Default DB !!");
                return new MongoCarData();
            }
            
        }

    }
}
