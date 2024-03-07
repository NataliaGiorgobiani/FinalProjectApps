namespace ATM
{
    internal class Program
    {


        static void Main(string[] args)
        {
            try
            {
                List<Customers> records = new List<Customers>();
                records.Add(new Customers());


                Console.WriteLine("Welcome to Tsutski Bank!");
                Console.WriteLine("Choose bank operation by number:");
                Console.WriteLine("1 - Login;");
                Console.WriteLine("2 - Registration;");
                Console.WriteLine("3 - Exit");

                char input = char.Parse(Console.ReadLine());
                switch (input)
                {
                    case '1':
                        Console.WriteLine("Pleas, Enter your user an password!");
                        Login(records);
                        break;

                    case '2':
                        Console.WriteLine("Lets Do it!");
                        Regist(records);
                        break;
                    case '3':
                        Console.WriteLine("Buy!");
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong format!:{ex.Message}");

            }

        }

            
        public static void Login(List<Customers> records)
        {
            try
            {
                Customers.Read();
                Customers customers = new Customers();
                Console.WriteLine("input you idnumber:");
                string idnumber = Console.ReadLine();
                Customers existingUser = Customers.Customer.Where(Customers => Customers.IdentityNumber == idnumber).FirstOrDefault();
                if (idnumber == null)
                {
                    Console.WriteLine("Check Your input!");

                }
                Console.WriteLine("Input your Password:");
                string password = Console.ReadLine();
                Customers existingPassword = Customers.Customer.Where(Customers => Customers.Password == password).FirstOrDefault();

                if (password != existingUser.Password)
                {
                    Console.WriteLine("Check your password!");
                }

                Options();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!!!:{ex.Message}");

            }

        }


        public static void Regist(List<Customers> records)
        {
            try
            {
                Customers.Read();
                Customers NewCusromer = new Customers();
                Customers customers = new Customers();



                Console.WriteLine("input your FirstName");
                NewCusromer.FirstName = Console.ReadLine();
                Console.WriteLine("input your LastName");
                NewCusromer.LastName = Console.ReadLine();
                Console.WriteLine("input your IDNumber");
                NewCusromer.IdentityNumber = Console.ReadLine();


                while (NewCusromer.IdentityNumber.Length != 11)
                {
                    Console.WriteLine("Please Enter 11-digit number:");
                    NewCusromer.IdentityNumber = Console.ReadLine();
                }

                if (Customers.Customer.Select(x => x.IdentityNumber).Contains(NewCusromer.IdentityNumber))
                {
                    Console.WriteLine("Already registered with this Identification Number.");
                    return;
                }

                NewCusromer.GeneratePassword();
                Console.WriteLine($"Your password is {NewCusromer.Password}");
                NewCusromer.Balance = 0;
                Customers.Save(NewCusromer);
                customers = NewCusromer;

                Options();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!!!:{ex.Message}");

            }

        }


        public static void Options()
        {
            try
            {
                Customers customers = new Customers();
                while (true)
                {
                    Console.WriteLine("Choose operations:");
                    Console.WriteLine("1 - Deposit");
                    Console.WriteLine("2-Withdraw");
                    Console.WriteLine("3-Check Balance");
                    Console.WriteLine("4 - Log out");
                    string amount = Console.ReadLine();
                    int money = int.Parse(amount);


                    char marked = char.Parse(Console.ReadLine());
                    switch (marked)
                    {
                        case '1':

                            Console.WriteLine("Enter amount of money:");
                            Customers.imp.DepositMoney(money);
                            Customers.Save(customers);
                            Console.WriteLine(Customers.Read);

                            break;

                        case '2':

                            Console.WriteLine("Enter amount of money:");
                            int input =int.Parse(Console.ReadLine());
                            customers.WithdrawMoney(money);
                            Customers.Save(customers);
                            break;

                        case '3':

                            Customers.imp.CheckWallet();
                            break;

                        case '4':

                            break;

                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!!!:{ex.Message}");

            }


        }
    }
}
