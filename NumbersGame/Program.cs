using static System.Console;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte attempts = 5;
            Random random = new Random();
            int randomNumber = random.Next(1, 2);
            int guessedNumber;
            bool guessedRightNumber = false;
            WriteLine("Välkommen!Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");
            
            while(attempts > 0)
            {
                guessedNumber = ReadLineInt();

                if (guessedNumber == randomNumber)
                {
                    guessedRightNumber = true;
                    break;
                }

                if (guessedNumber < randomNumber)
                {
                    WriteLine("Tyvärr du gissade för lågt!");

                }
                else if(guessedNumber > randomNumber)
                {
                    WriteLine("Tyvärr du gissade för högt!");
                }

                attempts--;
            }

            if (guessedRightNumber)
                WriteLine("Woho! Du gjorde det!");
            else
                WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");

                
        }

        static int ReadLineInt()
        {
            int answer;
            
            while (int.TryParse(ReadLine(), out answer))
            {
                WriteLine("Du måste gissa ett nummer!");
            }

            return answer;
        }
    }
}