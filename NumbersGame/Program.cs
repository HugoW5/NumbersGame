using System.Transactions;

namespace NumbersGame
{
	internal class Program
	{

		static int[] closeNum = { 0, 20, 40, 60, 80, 100 };
		//x --> 
		static string[] closePhrases = {
			"Väldigt Jätte nära!!",
			"Det var väldigt nära!",
			"Det bränns!",
			"Det börjar närma sig!",
			"Långt ifrån!",
			"Väldigt Långt ifrån",
		};

		static int tries = 5;

		static void Main(string[] args)
		{
			Random rng = new Random();
			int number = rng.Next(1, 21);
			Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

			while (tries > 0)
			{
				Console.Write("Gissning: ");
				int guess = 0;
				if (int.TryParse(Console.ReadLine(), out guess))
				{
					PrintPhrase(guess, number);
					tries--;
				}
			}
			if (tries == 0)
			{
				Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
			}
		}

		static void PrintPhrase(int guess, int number)
		{
			if (guess == number)
			{
				Console.WriteLine("Wohoo! Du gjorde det!");
				//make tries 0 to break while loop
				tries = 0;
				return;
			}

			double close = ((number - guess) * 100) / number;
			var nearest = closeNum.OrderBy(x => Math.Abs(x - close)).First();
			int index = closeNum.ToList().IndexOf(nearest);

			if (close < 1)
			{
				Console.WriteLine("För högt!");
			}
			else
			{
				Console.WriteLine(closePhrases[index]);
			}

		}
	}
}