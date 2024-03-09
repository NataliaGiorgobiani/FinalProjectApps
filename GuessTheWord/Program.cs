namespace GuessTheWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
             List<string> words = new List<string>
             {
                 "apple","banana","orange","grape","kiwi","strawberry","pineapple","blueberry","peach","watermelon"
             };
              Random choosen = new Random();

            while (true)
            {
                try
                {
                    int WordIndex = choosen.Next(words.Count);
                    string secretWord = words[WordIndex];

                    //Console.WriteLine(secretWord);

                    char[] symbole = new char[secretWord.Length];
                    for (int i = 0; i < symbole.Length; i++)
                    {
                        symbole[i] = '*';
                    }


                    int index = 6;

                    while (index > 0)
                    {
                        Console.WriteLine(symbole);
                        Console.Write("Iput a letter :");
                        char letter = char.Parse(Console.ReadLine());

                        if (secretWord.Contains(letter))
                        {
                            for (int i = 0; i < secretWord.Length; i++)
                            {
                                if (secretWord[i] == letter)
                                {
                                    symbole[i] = letter;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect guess.");
                        }

                        if (TestWinGame(symbole))
                        {
                            Console.WriteLine("Congratulations! You Won!");
                            break;
                        }

                        index--;
                        Console.WriteLine($"Is left: {index}");
                    }

                    if (!TestWinGame(symbole))
                    {
                        Console.WriteLine($"Sorry, you lost. The word was: {secretWord}");
                    }

                    Console.Write("Do you want Play again? (y/n): ");
                    string playAgain = Console.ReadLine();
                    if (playAgain != "y")
                        break;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wrong format!:{ex.Message}");

                }
            }
        }

       private static bool TestWinGame(char[] charsArray)
       {
            foreach (char c in charsArray)
            {
                if (c == '*')
                {
                    return false;
                }
            }
            
            return true;

        }
    }
}
