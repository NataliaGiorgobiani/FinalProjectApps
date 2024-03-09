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


                    int index = 0;

                    while (!TestWinGame(symbole, secretWord))
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

                        index++;
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

       private static bool TestWinGame(char[] charsArray, string secret)
       {
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] != charsArray[i])
                {
                   return false;
                }
            }
            return true;
            
       }
    }
}
