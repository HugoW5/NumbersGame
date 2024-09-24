namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int number = rng.Next(1, 21);
            int tries = 5;

            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

            while (tries > 0)
            {
                Console.Write("Gissning: ");
                int guess = 0;
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    if (guess < number)
                    {
                        Console.WriteLine("Tyvärr du gissade för lågt");
                    }
                    else if( guess > number)
                    {
                        Console.WriteLine("Tyvärr du gissade för högt!");
                    }
                    else
                    {
                        Console.WriteLine("Wohoo! Du gjorde det!");
                    }
                    tries--;
                }
            }
            Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
        }
    }
}
