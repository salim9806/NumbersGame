using static System.Console;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int guessedNumber;
            bool guessedRightNumber = false;
            
            SetDiffucultyLevel(out byte attempts, out int randomNumber, out (int min, int max) range);
 
            WriteLine($"\nVälkommen!Jag tänker på ett nummer mellan {range.min} och {range.max}. \nKan du gissa vilket? Du får {attempts} försök.\n");
            
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
            {
                WriteLine("\nTyvärr du lyckades inte gissa talet på fem försök!");
                WriteLine($"Jag tänkte på nummer {randomNumber}");
            }

                
        }

        static void SetDiffucultyLevel(out byte attempts, out int randomNumber, out (int min, int max) range)
        {
            WriteLine("Välj din svårighetsgrad:\n\t1) Enkel nivå \n\t2) Millannivå \n\t3) Svår nivå");
            switch (ReadLineIntWithinRange(1, 3))
            {
                case 1:
                    attempts = 6;
                    range = (1, 10);
                    randomNumber = new Random().Next(1, 10);
                    break;
                case 2:
                    attempts = 5;
                    range = (1, 25);
                    randomNumber = new Random().Next(1, 25);
                    break;
                case 3:
                    attempts = 3;
                    range = (1, 50);
                    randomNumber = new Random().Next(1, 50);
                    break;
                default:
                    attempts = 6;
                    range = (1, 10);
                    randomNumber = new Random().Next(1, 10);
                    break;

            }
        }

        static int ReadLineInt()
        {
            int answer;
            
            while (!int.TryParse(ReadLine(), out answer))
            {
                WriteLine("Du måste ge ett nummer!");
            }

            return answer;
        }

        static int ReadLineIntWithinRange(int min, int max)
        {
            int answer = ReadLineInt();

            while (answer < min || answer > max)
            {
                WriteLine($"Du måste ge ett nummer mellan {min} och {max}");
                answer = ReadLineInt();
            }

            return answer;
        }
    }
}