using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATM
{
    public class Customers
    {
        private const string _fileLocation = @"../../../customersdata.json";
        //public static List<Customers> Customer = new();
        private const string _fileLocationLog = @"../../../Log.txt";
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }

        public static List<Customers> Customer = new();
       

        public void DepositMoney(int amount)
        {
            Balance += amount;
        }
        public void WithdrawMoney(int amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds!");
                return;
            }

            Balance -= amount;
        }
        public void CheckWallet()
        {
            Console.WriteLine($"Account Balance is : {this.Balance}");
        }
        public void GeneratePassword()
        {
            Random random = new Random();

            while (true)
            {
                string first = random.Next(0, 9).ToString();
                string lastThree = random.Next(100, 999).ToString();
                string finalVersion = first + lastThree;
                if (!Customer.Select(x => x.Password).Contains(finalVersion))
                {
                    Password = finalVersion;
                    break;
                }

            }

        }
        public void Registration(Customers model)
        {
            model.Id = Customer.Max(x => x.Id) + 1;
            Customer.Add(model);
        }
        public static void Read()
        {
            var data = File.ReadAllText(_fileLocation);
            Customer = Parse(data);
            return;
        }

        private static List<Customers> Parse(string input)
        {
            var result = JsonSerializer.Deserialize<List<Customers>>(input);
            return result;
        }

        private static string ToJson(Customers input)
        {
            string result = JsonSerializer.Serialize(input);
            return result;
        }


        public Customers GetSingleCustomer(int id)
        {
            var result = Customer.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new NullReferenceException("Data not found");
            }
            return result;
        }

        public static void Save(Customers model)
        {
            if (Customer.Count == 0)
            {
                model.Id = 1;
            }
            else
            {
                model.Id = Customer.Max(x => x.Id) + 1;
            }
            Customer.Add(model);
            string json = JsonSerializer.Serialize(Customer, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_fileLocation, json);
        }
        public static void Loginfo(Customers customer)
        {
            string logEntry = $"{DateTime.Now}: Customer with ID {customer.Id} - {customer.FirstName} {customer.LastName} {customer.Balance}";
            File.AppendAllText(_fileLocationLog, logEntry + Environment.NewLine);

        }
            
    }
}
