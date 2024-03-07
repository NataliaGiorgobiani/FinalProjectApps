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
        private const string _fileLocation = "C:\\Users\\madnj\\OneDrive\\Desktop\\Final\\ATM\\customersdata.json";
        public static List<Customers> Customer = new();
        private const string _fileLocationLog = "C:\\Users\\madnj\\OneDrive\\Desktop\\Final\\ATM\\Log.json";

        public static Customers imp = new();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }



        public void DepositMoney(int money)
        {
            imp.Balance += money;
        }

        public void WithdrawMoney(int money)
        {
            imp.Balance -= money;
        }

        public void CheckWallet()
        {
            Console.WriteLine($"Account Balance: {imp.Balance}");
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

            string json1 = JsonSerializer.Serialize(Customer, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_fileLocationLog, json);

        }

        /*public static void SaveOperation(Customers operations)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            operations.Add(Customers.Save);
            string json = JsonSerializer.Serialize(Operations, options);
            File.WriteAllText(_fileLocationLog, json);
        }
*/


    }
}
