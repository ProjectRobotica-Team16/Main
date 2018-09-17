using System;
using MonoBrick.EV3;

namespace src
{
	class Program
	{
		static void Main(string[] args)
		{
			var brick = new Brick<Sensor, Sensor, Sensor, Sensor>("WiFi");
			ConsoleKeyInfo cki;
			try
			{
				brick.Connection.Open();
				//Programma Hier
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
