using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Web.Configuration;

namespace TraumenAuto.Factory
{
    class FeatureDataFactory
    {

        public static IFeatureRepository GetCarFeatureStoreType()
        {
            // Read DBConnName From Web Config File 
            string DBConnObject = WebConfigurationManager.AppSettings["FeatureData"];
            if (DBConnObject != null)
            {
                IFeatureRepository FeatureObj;
                var handle = Activator.CreateInstance("DataLayer", DBConnObject);
                var Obj = handle.Unwrap();
                FeatureObj = (IFeatureRepository)Obj;
                return FeatureObj;

            }
            else
            {
                return new MongoFeatureData();
            }

            
        }
    }
}
