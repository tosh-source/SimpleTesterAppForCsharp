using System;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

namespace SimpleTesterApp
{
	public class Input
	{
		public static void UserData()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //set default culture

			//1.Define path directory
			Console.Write("Take test files from current directory ");
			string choice = yesOrNoQuestion();

			string directory = String.Empty;

			if (choice == string.Empty || choice[0] == 'Y' || choice[0] == 'y')  //choise == string.Empty -> when user press <Enter>
			{
				//do not delete this statement, it will prevent exeption when user press <Enter>
			}
			else if (choice[0] == 'N' || choice[0] == 'n')
			{
				directory = string.Format(@"" + Console.ReadLine());
			}
			else
			{
				throw new ArgumentException("Invalid input data!");
			}

			//2.Define file name
			Console.Write("The program will looking for files with this pattern: \"test001.in.txt\" ");
			choice = yesOrNoQuestion();

			string fileName = "test";
			string fileExtension = ".txt";

			if (choice == string.Empty || choice[0] == 'Y' || choice[0] == 'y')  //choise == string.Empty -> when user press <Enter>
			{
				//do not delete this statement, it will prevent exeption when user press <Enter>
			}
			else if (choice[0] == 'N' || choice[0] == 'n')
			{
				Console.Write("Type file name pattern (e.g.: myTestFiles001.txt): ");
				Console.ForegroundColor = ConsoleColor.Red;
				fileName = Console.ReadLine();
				Console.ResetColor();

				if (!(Regex.IsMatch(fileName, string.Format(@"\b{0}\b", fileExtension))))
				{
					Console.WriteLine("The default files should be in TXT format, but you type something different..");
					Console.Write("Do you want to use default TXT extension ");
					choice = yesOrNoQuestion();

					if (choice[0] == 'N' || choice[0] == 'n')
					{
						throw new ArgumentException("Invalid file extension!");
					}

					fileName = fileName.Remove(fileName.LastIndexOf('.'));
					fileName = fileName.TrimEnd('.');
					fileName = fileName + fileExtension;
				}

				Console.WriteLine("The program will try to find next test files..");
			}
			else
			{
				throw new ArgumentException("Invalid input data!");
			}
		}

		private static string yesOrNoQuestion()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("(Y/n)");
			Console.ResetColor();
			Console.Write(" ? : ");
			Console.ForegroundColor = ConsoleColor.Red;
			string choice = Console.ReadLine();
			Console.ResetColor();

			return choice;
		}
	}
}
