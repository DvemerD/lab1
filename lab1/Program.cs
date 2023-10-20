using System;
using System.Text.RegularExpressions;

namespace lab1 
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string email = "";
            string phoneNumber = "";
            bool isValidNumber = false;
            bool isValidName = false;
            bool isValidEmail = false;

            while (!isValidName)
            {
                Console.WriteLine("Enter your name:");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid entered name");
                }
                else
                {
                    isValidName = true;
                }
            }


            while (!isValidEmail)
            {
                Console.WriteLine("Enter your email:");
                email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Invalid entered email");
                }
                else
                {
                    isValidEmail = true;
                }
            }
            
            while (!isValidNumber)
            {
                Console.WriteLine("Enter your phone number:");
                phoneNumber = Console.ReadLine();

                if (!Regex.IsMatch(phoneNumber, @"^[0-9]{10}$"))
                {
                    Console.WriteLine("Invalid phone number");
                }
                else
                {
                    isValidNumber = true;
                }
            }

            ClientCard card = new ClientCard(name, email, phoneNumber);

            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("\nSelect operation:");
                Console.WriteLine("1. Send a parcel");
                Console.WriteLine("2. Receive a parcel");
                Console.WriteLine("3. History of postal operations");
                Console.WriteLine("4. Incomplete postal transactions");
                Console.WriteLine("5. The sum of funds of all operations");
                Console.WriteLine("0. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("\nRecipient's postal code:");
                            int code = int.Parse(Console.ReadLine());
                            Console.WriteLine("Recipient's phone number:");
                            string phone = Console.ReadLine();
                            Console.WriteLine("Parcel weight:");
                            double weight = double.Parse(Console.ReadLine());

                            Console.WriteLine($"\nPrice: {card.SendParcel(code, phone, weight)}$");
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine("\nSender's postal code:");
                            int code = int.Parse(Console.ReadLine());
                            Console.WriteLine("Sender's phone number:");
                            string phone = Console.ReadLine();

                            Console.WriteLine($"\nPrice: {card.ReceiveParcel(code, phone)}$");
                        }
                        break;
                    case "3":
                        {
                            if (card.GetUnfinishedOperationsy() == null)
                            {
                                Console.WriteLine("\nTransaction history is empty.");
                            } else
                            {
                                Console.WriteLine("\nHistory of postal operations:\n");

                                foreach (var operation in card.GetUnfinishedOperationsy())
                                {
                                    Console.WriteLine($"Operation Type: {operation.Type}");
                                    Console.WriteLine($"Completion status: {(operation.IsCompleted ? "Сompleted" : "Not completed")}");
                                    Console.WriteLine($"Postal code: {operation.PostNumber}");
                                    Console.WriteLine($"Phone Number: {operation.PhoneNumber}");
                                    if (operation.ParcelWeight != 0) Console.WriteLine($"Parcel Weight: {operation.ParcelWeight}");
                                    Console.WriteLine($"Shipping Cost: {operation.Price}$");
                                    Console.WriteLine($"Operation Date: {operation.Date}");
                                    Console.WriteLine("--------------------------------------------------");
                                }
                            }   
                        }
                        break;
                    case "4":
                        {
                            if (card.GetOperationHistory() == null)
                            {
                                Console.WriteLine("\nThere are no unfinished transactions");
                            }
                            else
                            {
                                Console.WriteLine("\nUnfinished operations:\n");

                                foreach (var operation in card.GetOperationHistory())
                                {
                                    Console.WriteLine($"Operation Type: {operation.Type}");
                                    Console.WriteLine($"Completion status: {(operation.IsCompleted ? "Сompleted" : "Not completed")}");
                                    Console.WriteLine($"Postal code: {operation.PostNumber}");
                                    Console.WriteLine($"Phone Number: {operation.PhoneNumber}");
                                    if (operation.ParcelWeight != 0) Console.WriteLine($"Parcel Weight: {operation.ParcelWeight}");
                                    Console.WriteLine($"Shipping Cost: {operation.Price}$");
                                    Console.WriteLine($"Operation Date: {operation.Date}");
                                    Console.WriteLine("--------------------------------------------------");
                                }
                            }
                        }
                        break;
                    case "5":
                        {
                            Console.WriteLine($"The amount of funds spent on postal operations: {card.getFundsTotal()}$");    
                        }
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nIncorrect choice. Try again.");
                        break;
                }
            }
        }
    }
}
