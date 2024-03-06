namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input first number:");
                double Number1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Input secound number");
                double Number2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Choose operation : (+, -, *, /) ");
                char operation = char.Parse(Console.ReadLine());

                switch (operation)
                {
                    case '+':
                        Console.WriteLine(Number1 + Number2);
                        break;

                    case '-':
                        Console.WriteLine(Number1 - Number2);
                        break;
                    case '/':
                        Console.WriteLine(Number1 / Number2);
                        break;
                    case '*':
                        Console.WriteLine(Number1 * Number2);
                        break;

                }

                if (operation != '-' || operation != '+' || operation != '/' || operation != '*')
                    Console.WriteLine("Operation is not correct! Choose another!");


                Console.WriteLine("Do yo want to continue: y or n?");
                char answer = char.Parse(Console.ReadLine());
                if (answer == 'n')
                    break;
            }

        }
    }
}
