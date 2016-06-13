using System;

class Program
{       
	static void Main(string [] argv)       
	{               
		if (argv.Length != 2)               
		{                       
			Console.WriteLine("Use: Calc [number] [number], for example: Calc 10 6");                       
			return;               
		}               
		try               
		{                       
			int x = int.Parse(argv[0]);                       
			int y = int.Parse(argv[1]);                                              

			Console.WriteLine($"{x} + {y} = {Calc.Add(x,y)}");                       
			Console.WriteLine($"{x} - {y} = {Calc.Subtract(x,y)}");               
		}               
		catch(Exception ex)               
		{                       
			Console.WriteLine(ex.Message);               
		}       
	} 
} 