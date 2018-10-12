using System;
using System.Threading;
using MonoBrick;
using MonoBrick.EV3;

namespace src
{
	class Program
	{
		private static bool up = false, down = false;

		private static Brick<Sensor, Sensor, Sensor, Sensor> brick;

		static void Main(string[] args)
		{
			brick = new Brick<Sensor, Sensor, Sensor, Sensor>("WiFi");
			try
			{
				brick.Connection.Open();
			}
			catch (ConnectionException ce)
			{
				Console.WriteLine(ce.Message);
				return;
			}
			// 2160° (6 · 360°) is een volledige bocht naar links of rechts
			// Arm (Motor C): positief = omlaag, negatief = omhoog
			// Grijper (Arm): 120 graden omhoog max
			// http://firstlegoleague.nl/deelnemers/challenge/
			keys();
		}

		static void keys()
		{
			bool running = true;
			while (running)
			{
				String pressedKey = Console.ReadKey().Key.ToString();
				switch (pressedKey)
				{
					case "UpArrow":
						if (down)
						{
							down = false;
							brick.MotorA.Off();
						}
						else if (!up)
						{
							up = true;
							brick.MotorA.On(-5);
						}
						break;
					case "DownArrow":
						if (up)
						{
							up = false;
							brick.MotorA.Off();
						}
						else if (!down)
						{
							down = true;
							brick.MotorA.On(5);
						}
						break;
					case "RightArrow":
						brick.MotorB.On(30, 2160, true);
						break;
					case "LeftArrow":
						brick.MotorB.On(-30, 2160, true);
						break;
					case "Escape":
						running = false;
						break;
				}
			}
		}

		static void sleep(int ms)
		{
			Thread.Sleep(ms);
		}
	}
}

class DistanceSensor : Sensor
{
	/**
	 *
	 * Reads the distance in centimeters, returns a float.
	 *
	 */
	public float Read()
	{
		return float.Parse(this.ReadAsString());
	}
}

class TouchSensor : MonoBrick.EV3.TouchSensor
{
	/**
	 *
	 * Reads the value as a boolean.
	 *
	 */
	public bool ReadAsBoolean()
	{
		int value = this.Read();
		if (value == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}