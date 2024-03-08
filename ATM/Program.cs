namespace ATM
{
    internal class Program
    {
     
        static void Main(string[] args)
        {
          
            while (true)
            {
                try
                {
                    List<Customers> records = new List<Customers>();

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
                            Login();
                            break;
                        case '2':
                            Console.WriteLine("Lets Do it!");
                            Regist();
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

        }    
        public static void Login()
        {
            try
            {
                Customers.Read();
                //Customers customers = new Customers();
                Console.WriteLine("input you idnumber:");
                string idnumber = Console.ReadLine();
                Customers existingUser = Customers.Customer.FirstOrDefault(c => c.IdentityNumber == idnumber);
                if (existingUser == null)
                {
                    Console.WriteLine("Check Your input!");
                    return;
                }
                Console.WriteLine("Input your Password:");
                string password = Console.ReadLine();
                if (password != existingUser.Password)
                {
                    Console.WriteLine("Check your password!");
                    return;
                }
                Console.WriteLine($"Welcome back, {existingUser.FirstName} {existingUser.LastName}!");
                Console.WriteLine($"Your current balance is: {existingUser.Balance}");

                Options(existingUser);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!!!:{ex.Message}");
            }
        }
        public static void Regist()
        {
            try
            {
                Customers.Read();
                Customers NewCusromer = new();
                
                Console.WriteLine("input your FirstName");
                NewCusromer.FirstName = Console.ReadLine();
                Console.WriteLine("input your LastName");
                NewCusromer.LastName = Console.ReadLine();
                Console.WriteLine("input your IDNumber");
                NewCusromer.IdentityNumber = Console.ReadLine();

                while (NewCusromer.IdentityNumber.Length != 11)
                {
                    Console.WriteLine("Please Enter a 11-digit number:");
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
                NewCusromer.Registration(NewCusromer);
                Options(NewCusromer);
               

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error!!!:{ex.Message}");
            }

        }
        public static void Options(Customers customer)
        {
            try
            {
                //Customers customers = new();
                while (true)
                {
                    Console.WriteLine("Choose operations:");
                    Console.WriteLine("1 - Deposit");
                    Console.WriteLine("2-Withdraw");
                    Console.WriteLine("3-Check Balance");
                    Console.WriteLine("4 - Log out");
                   // string amount = Console.ReadLine();
                    //int money = 0;


                    char marked = char.Parse(Console.ReadLine());
                    switch (marked)
                    {
                        case '1':

                            Console.WriteLine("Enter amount of money:");
                            int depositAmount = int.Parse(Console.ReadLine());
                            customer.DepositMoney(depositAmount);
                            Customers.Save(customer);
                            Console.WriteLine("Done!");
                            Customers.Loginfo();
                            //Console.WriteLine(Customers.Read);

                            break;

                        case '2':

                            Console.WriteLine("Enter amount of money:");
                            int withdrawAmount = int.Parse(Console.ReadLine());
                            customer.WithdrawMoney(withdrawAmount);
                            Customers.Save(customer);
                            Console.WriteLine("Done!");
                            Customers.Loginfo();
                            break;

                        case '3':

                            customer.CheckWallet();
                            Customers.Loginfo();
                            break;

                        case '4':
                            Console.WriteLine("Logged out!");
                            return; 
                        default:
                            Console.WriteLine("Invalid option!");
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
