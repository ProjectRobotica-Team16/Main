using MonoBrick.EV3;

namespace src
{
	class DistanceSensor : Sensor
	{
		/**
		 *
		 * Reads the distance in centimeters, returns a float.
		 *
		 */
		public float Read()
		{
			return float.Parse(ReadAsString());
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
			int value = Read();
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
}
