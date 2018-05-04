﻿using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace SimpleTesterApp
{
	public class Input
	{
		public static void UserData()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; //set default culture

			//Define path directory
			Console.Write("Take test files from current directory ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("(Y/n)");
			Console.ResetColor();
			Console.Write(" ? : ");
			Console.ForegroundColor = ConsoleColor.Red;
			var choise = Console.ReadLine();
			Console.ResetColor();

			string directory = String.Empty;

			if (choise == string.Empty || choise[0] == 'Y' || choise[0] == 'y')  //choise == string.Empty -> when user press <Enter>
			{
				//do not delete this statement, it will prevent exeption when user press <Enter>
			}
			else if (choise[0] == 'N' || choise[0] == 'n')
			{
				directory = string.Format(@"" + Console.ReadLine());
			}
			else
			{
				throw new ArgumentException("Invalid input data!");
			}

			Console.Write("The program will looking for files with this pattern: \"test....txt\" ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("(Y/n)");
			Console.ResetColor();
			Console.Write(" ? : ");
			Console.ForegroundColor = ConsoleColor.Red;
            choise = Console.ReadLine();
			Console.ResetColor();

			string fileName = "test";
			string fileExtension = ".txt";

			if (choise == string.Empty || choise[0] == 'Y' || choise[0] == 'y')  //choise == string.Empty -> when user press <Enter>
			{
				//do not delete this statement, it will prevent exeption when user press <Enter>
			}
			else if (choise[0] == 'N' || choise[0] == 'n')
			{
				fileName = Console.ReadLine();

				fileExtension = Console.ReadLine();
				if (!(fileExtension[0] == '.'))
				{
					fileExtension = '.' + fileExtension;
				}
			}
			else
			{
				throw new ArgumentException("Invalid input data");
			}
		}
	}
}
