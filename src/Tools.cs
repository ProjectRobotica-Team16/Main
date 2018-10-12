using MonoBrick.EV3;
using System;
using System.Threading;

namespace src
{
	class Tools
	{
		private static bool up = false, down = false;

		public static Brick<Sensor, Sensor, Sensor, Sensor> brick = new Brick<Sensor, Sensor, Sensor, Sensor>("WiFi");

		public static void DevControl()
		{
			bool running = true;
			while (running)
			{
				String pressedKey = Console.ReadKey(true).Key.ToString();
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
						Threaded(Program.Right);
						break;
					case "LeftArrow":
						Threaded(Program.Left);
						break;
					case "S":
						Threaded(Program.Slaan);
						break;
					case "O":
						Program.Off();
						break;
					case "Escape":
						Console.WriteLine("Waiting for all threads to stop.");
						running = false;
						break;
				}
			}
		}

		public static void Threaded(Action action, bool disableRegistry)
		{
			if (ActivationRegistry.Register(action) || disableRegistry)
			{
				ThreadStart ts = new ThreadStart(action);
				ts += () =>
				{
					ActivationRegistry.Deregister(action);
				};
				Thread t = new Thread(ts);
				t.Start();
			}
		}

		public static void Threaded(Action action)
		{
			Threaded(action, false);
		}

		public static void Sleep(int ms)
		{
			Thread.Sleep(ms);
		}
	}
}