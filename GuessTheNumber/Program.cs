namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose level:easy - e, medium - m, hard - h");
                    char level = char.Parse(Console.ReadLine());
                    Random number = new Random();
                    int GeneredNumber = 0;


                    if (level == 'e')
                    {
                        GeneredNumber = number.Next(1, 25);
                    }
                    else if (level == 'm')
                    {
                        GeneredNumber = number.Next(1, 50);
                    }
                    else if (level == 'h')
                    {
                        GeneredNumber = number.Next(1, 100);
                    }
                    else
                    {
                        throw new Exception("inputed parameter is not correct!");
                    }


                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine("input your number:");
                        int selected = int.Parse(Console.ReadLine());
                        int rand = number.Next();
                        if (GeneredNumber < selected && i != 10)
                        {
                            Console.WriteLine("Your number is High! Reduce it!");
                        }
                        else if (GeneredNumber > selected && i != 10)
                        {
                            Console.WriteLine("Your number is Low! Increase it");
                        }
                        else if (GeneredNumber == selected)
                        {
                            Console.WriteLine("Congratulations!You Won!");
                            break;
                        }
                        else if (i == 10)
                        {
                            Console.WriteLine("Sorry, you lose!");
                            break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Somthing Wrong!: {ex.Message}");
                }
            }
        }
    }
}
