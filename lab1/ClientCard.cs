using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class ClientCard
    {
        private string Name { get; set; }
        private string Email { get; set; }
        private string Id { get; set; }
        private string PhoneNumber { get; set; }
        private List<Operation> OperationHistory { get; set; }
        private List<Operation> UnfinishedOperations { get; set; }

        public ClientCard(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            Id = IDGenerator.GenerateRandomId(16);
            PhoneNumber = phoneNumber;
        }

        public decimal SendParcel(int postNumber, string phoneNumber, double parcelWeight)
        {
            decimal price = ShippingCalculator.CalculateShippingCost(parcelWeight);
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);

            Operation newOperation = new Operation(OperationType.Sending, postNumber, phoneNumber, price, date, false, parcelWeight);

            if (OperationHistory == null)
            {
                OperationHistory = new List<Operation>();
            }
            if (UnfinishedOperations == null)
            {
                UnfinishedOperations = new List<Operation>();
            }

            OperationHistory.Add(newOperation);
            UnfinishedOperations.Add(newOperation);

            return price;    
        }

        public decimal ReceiveParcel(int postNumber, string phoneNumber)
        {
            decimal price = 20;
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);

            Operation newOperation = new Operation(OperationType.Receiving, postNumber, phoneNumber, price, date, true);

            if (OperationHistory == null)
            {
                OperationHistory = new List<Operation>();
            }

            OperationHistory.Add(newOperation);

            return price;
        }
        public List<Operation> GetOperationHistory()
        {
            return OperationHistory;
        }
        public List<Operation> GetUnfinishedOperationsy()
        {
            foreach (var operation in OperationHistory)
            {
                if (operation.IsCompleted)
                {
                    UnfinishedOperations.Add(operation);
                }
            }

            return UnfinishedOperations;
        }
        public decimal getFundsTotal()
        {
            if (OperationHistory == null)
            {
                return 0;
            }

            decimal fundsTotal = 0;

            foreach (var operation in OperationHistory)
            {
                fundsTotal += operation.Price;
            }

            return fundsTotal;
        }
    }
}
