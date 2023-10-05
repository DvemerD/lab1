using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class ShippingCalculator
    {
        public static decimal CalculateShippingCost(double weight)
        {
            decimal baseRate = 5.0m; 
            decimal ratePerKg = 2.0m; 

            decimal shippingCost = baseRate + ((decimal)weight * ratePerKg);

            return shippingCost;
        }
    }
}
