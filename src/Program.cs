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
			catch (ConnectionException ce)
			{
				Console.WriteLine(ce.Message);
				return;
			}
			// 2160� van t is de volledige slag naar links of recht
			// Programma hier
		}

		static void sleep(int ms)
		{
			System.Threading.Thread.Sleep(ms);
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