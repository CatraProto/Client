using System;

namespace CatraProto.TL
{
	public static class FlagsHelper
	{
		public static int SetFlag(int flagInt, int value)
		{
			if (IsFlagSet(flagInt, value))
			{
				return flagInt;
			}

			return flagInt | (1 << value);
		}

		public static int UnsetFlag(int flagInt, int value)
		{
			if (!IsFlagSet(flagInt, value))
			{
				return flagInt;
			}

			return flagInt & ~(1 << value);
		}

		public static bool IsFlagSet(int flagInt, int value)
		{
            return (flagInt & (1 << value)) != 0;
		}
	}
}