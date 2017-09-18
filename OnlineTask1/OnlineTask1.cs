namespace OnlineTask1
{
    //Given: sorted array of integers
    //Return: sorted array of squares of those integers.Integers can be negative.
    //Ex: [1,3,5] -> [1,9,25]
    public static class OnlineTask1
    {
        public static int[] ArrayPow2(int[] input)
        {
            if (input == null) return null;
            // TODO validate on input sorting

            int cur1 = 0;
            int cur2 = input.Length - 1;
            var output = new int[input.Length];
            int curOut = cur2;
            while (cur1 <= cur2)
            {
                int value1 = input[cur1];
                value1 *= value1;

                if (cur1 == cur2)
                {
                    output[curOut] = value1;
                    break;
                }

                int value2 = input[cur2];
                value2 *= value2;

                if (value1 >= value2)
                {
                    output[curOut] = value1;
                    curOut--;
                    cur1++;
                }

                if (value1 <= value2)
                {
                    output[curOut] = value2;
                    curOut--;
                    cur2--;
                }
            }

            return output;
        }
    }
}