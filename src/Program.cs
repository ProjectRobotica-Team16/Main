using System;
using MonoBrick;
using MonoBrick.EV3;

namespace src
{
	class Program
	{
		private static Brick<Sensor, Sensor, Sensor, Sensor> brick = Tools.brick;

		static void Main(string[] args)
		{
			try
			{
				brick.Connection.Open();
				Console.WriteLine("Connected");
			}
			catch (ConnectionException ce)
			{
				Console.WriteLine(ce.Message);
				return;
			}
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnExit);
			// 2160° (6 · 360°) is een volledige bocht naar links of rechts
			// Arm (Motor C): positief = omlaag, negatief = omhoog
			// Grijper (Arm): 120 graden omhoog max
			// http://firstlegoleague.nl/deelnemers/challenge/
			//AutoControl();
			Tools.DevControl();
		}

		private static void OnExit(object sender, EventArgs e)
		{
			Console.WriteLine("Application ended, press a key to exit.");
			Console.ReadKey(true);
		}

		private static void AutoControl()
		{
			brick.MotorB.On(100, 10, true);
			Tools.Sleep(1000);
			Off();
		}

		public static void Off()
		{
			brick.MotorA.Off();
			brick.MotorB.Off();
			brick.MotorC.Off();
			brick.MotorD.Off();
		}

		public static void Left()
		{
			brick.MotorB.On(-30, 2160, true);
		}

		public static void Right()
		{
			brick.MotorB.On(30, 2160, true);
		}

		/**
		 *
		 * Slaat met de arm.
		 *
		 */
		public static void Slaan()
		{
			uint degrees = 140;
			sbyte speed = 100;
			int ms = speed * 10;
			//
			Motor m = brick.MotorC;
			m.On(speed, degrees, true);
			Tools.Sleep(ms);
			m.Reverse = true;
			m.On((sbyte)(speed / 4), degrees, true);
			Tools.Sleep(ms * 3);
			m.Reverse = false;
		}
	}
}