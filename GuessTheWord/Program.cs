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
            int WordIndex = choosen.Next(words.Count);
            string secretWord = words[WordIndex];

            //Console.WriteLine(secretWord);
            char[] symbole = new char[secretWord.Length];
            for (int i = 0; i < symbole.Length; i++)
            {
                symbole[i] = '*';
            }



            Console.WriteLine(symbole); // simboloebiT agniSvna

            Console.Write("Iput a letter :");
            char letter = char.Parse(Console.ReadLine());

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (letter == secretWord[i])
                {
                    symbole[i] = letter;    // simbolos Canacvleba 
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
