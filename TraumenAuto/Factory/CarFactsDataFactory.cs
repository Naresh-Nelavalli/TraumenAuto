using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Web.Configuration;

namespace TraumenAuto.Factory
{
    class CarFactsDataFactory
    {

        public static ICarFactsRepository GetCarFactsStoreType()
        {
            // Read DBConnName From Web Config File 
            string DBConnObject = WebConfigurationManager.AppSettings["CarFactsData"];
            if (DBConnObject != null)
            {
                ICarFactsRepository FactsRepositoryTypeObj;
                var handle = Activator.CreateInstance("DataLayer", DBConnObject);
                var Obj = handle.Unwrap();
                FactsRepositoryTypeObj = (ICarFactsRepository)Obj;
                return FactsRepositoryTypeObj;
            }
            else
            {
                return new MongoCarFactsData();

            }
        }
    }
}
