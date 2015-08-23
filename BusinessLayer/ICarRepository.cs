using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ICarRepository
    {
        List<Car> GetCars(InputRequestAttributes RequestQuery);
        Car GetCarDetails(String Vin);
        void StoreCartoDb(Car newCarDetails);
        Dictionary<string, List<string>> GetCarModels();
    }
}
