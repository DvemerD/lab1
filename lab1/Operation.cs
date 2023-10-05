using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Operation
    {
        public OperationType Type { get; set; }
        public int PostNumber { get; set; }
        public string PhoneNumber { get; set; }
        public double ParcelWeight { get; set; }
        public decimal Price { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly Date { get; set; }

        public Operation(OperationType type, int postNumber, string phoneNumber, decimal price, DateOnly date, bool isCompleted, double parcelWeight = 0)
        {
            Type = type;
            PostNumber = postNumber;
            PhoneNumber = phoneNumber;
            ParcelWeight = parcelWeight;
            Price = price;
            IsCompleted = isCompleted;
            Date = date;
        }
    }
}
