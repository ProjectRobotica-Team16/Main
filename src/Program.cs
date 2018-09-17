using System;
using MonoBrick;
using MonoBrick.EV3;

namespace src
{
	class Program
	{
		static void Main(string[] args)
		{
			var brick = new Brick<Sensor, Sensor, Sensor, Sensor>("WiFi");
			try
			{
				brick.Connection.Open();
			}
			catch (ConnectionException e)
			{
				Console.WriteLine(e.Message);
				return;
			}
			//Programma hier
		}
	}
}