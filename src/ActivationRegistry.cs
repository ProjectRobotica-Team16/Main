using System;
using System.Collections.Generic;

namespace src
{
	class ActivationRegistry
	{
		private static readonly List<Action> registry = new List<Action>();

		public static bool Register(Action a)
		{
			if (!registry.Contains(a))
			{
				registry.Add(a);
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool IsRegistered(Action a)
		{
			return registry.Contains(a);
		}

		public static bool Deregister(Action a)
		{
			return registry.Remove(a);
		}
	}
}
