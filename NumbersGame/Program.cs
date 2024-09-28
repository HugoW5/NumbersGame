using System.Transactions;

namespace NumbersGame
{
	internal class Program
	{

		static int[] closeNum = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
		//x -->
		static string[] closePhrases = {
			"Perfekt! Spot on!",
			"Väldigt Jätte nära!!",
			"Det var väldigt nära!",
			"Det bränns!",
			"Du är nästan där!",
			"Det börjar närma sig!",
			"Inte så långt ifrån.",
			"Det är lite avstånd kvar.",
			"Långt ifrån!",
			"Väldigt långt ifrån!",
			"Helt ute och cyklar!",
			};

		static ConsoleColor[] closeColors = {
			ConsoleColor.Green,
			ConsoleColor.Green,
			ConsoleColor.DarkGreen,
			ConsoleColor.Yellow,
			ConsoleColor.DarkYellow,
			ConsoleColor.DarkYellow,
			ConsoleColor.DarkGray,
			ConsoleColor.Gray,
			ConsoleColor.DarkRed,
			ConsoleColor.Red,
			ConsoleColor.Red
			};

		static int tries = 5;

		static void Main(string[] args)
		{
			Random rng = new Random();
			int number = rng.Next(1, 21);
			Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

			while (tries > 0)
			{
				Console.Write($"Gissning (");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(tries);
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("):");
				int guess = 0;
				if (int.TryParse(Console.ReadLine(), out guess))
				{
					CheckNum(guess, number);
					tries--;
				}
			}
			if (tries == 0)
			{
				Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
			}
		}

		static void CheckNum(int guess, int number)
		{
			if (guess == number)
			{
				Console.WriteLine("Wohoo! Du gjorde det!");
				//make tries 0 to break while loop
				tries = 0;
				return;
			}

			// absolute percentage difference between the guess and the correct number.
			double close = (Math.Abs(number - guess) * 100) / number;

			// Finds the closest value in the closeNum array to the calculated percentage difference.
			var nearest = closeNum.OrderBy(x => Math.Abs(x - close)).First();

			// Gets the index of the closest value in closeNum, to match the corresponding phrase.
			int index = closeNum.ToList().IndexOf(nearest);



			if (close < 1)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("För högt!");
			}
			else
			{
				Console.ForegroundColor= closeColors[index];
				Console.WriteLine(closePhrases[index]);
			}
			//reset fg color
			Console.ForegroundColor = ConsoleColor.White;


		}
	}
}
