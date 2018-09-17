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
				do
				{
					cki = Console.ReadKey(true);
					switch (cki.Key)
					{
						case ConsoleKey.UpArrow:
							brick.MotorA.On(30);
							break;
						case ConsoleKey.DownArrow:
							brick.MotorA.On(-30);
							break;
					}
				} while (!cki.Key.ToString().Equals("Escape"));
				if (brick.MotorA.IsRunning())
				{
					brick.MotorA.Off();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}