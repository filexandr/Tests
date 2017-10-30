namespace Task68
{
	// 68. Reverse the bits of an unsigned integer.
	// Time: O(1)
	// Space: O(1)
	public static class Task68
	{
		public static uint ReverseInteger (uint value)
		{
			if (value == 0 || value == uint.MaxValue)
				return value;

			uint result = 0;
			uint bitValue = 1;
		    uint reverseBitValue = 2147483648;
            for (int i = 1; i < 32; i++) {
				if ((value & bitValue) == bitValue)
                {
					result |= reverseBitValue;
				}

				bitValue <<= 1;
				reverseBitValue >>= 1;
			}

			return result;
		}
	}
}