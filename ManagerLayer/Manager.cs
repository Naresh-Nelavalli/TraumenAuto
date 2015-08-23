using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace ManagerLayer
{
    public class Manager
    {

        public List<Car> SortCars(string sortOrder, List<Car> carsList)
        {
           
            List<Car> SortedList;
            switch (sortOrder)
            {
                case "price":
                    {
                        SortedList = carsList.OrderBy(o => o.Price).ToList();
                        break;
                    }
                case "mileage":
                    {
                        SortedList = carsList.OrderBy(o => o.Mileage).ToList();
                        break;
                    }
                case "price_desc":
                    {
                        SortedList = carsList.OrderByDescending(o => o.Price).ToList();
                        break;
                    }
                case "mileage_desc":
                    {
                        SortedList = carsList.OrderByDescending(o => o.Mileage).ToList();
                        break;
                    }
                default:

                    SortedList = carsList;
                    break;
            }
            return SortedList;

        }
    }
}
