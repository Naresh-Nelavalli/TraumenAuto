using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public  class InputRequestAttributes
    {

        public string Vin     { get; set; }
        public string Name   { get; set; }
        public int Year      { get; set; }
        public string Maker  { get; set; }
        public int Odometer  { get; set; }
        public int MinPrice  { get; set; }
        public int MaxPrice  { get; set; }
        public double Mileage { get; set; }
        public string StoreName { get; set; }
        public string Zipcode { get; set; }
        public string Color    { get; set; }
        public int   distance { get; set; }
    }
}
