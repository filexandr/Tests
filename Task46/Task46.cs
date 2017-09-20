namespace Task46
{
    // 46.Give a fast way to multiply a number by 7. 
    // Time: O(1)
    // Space: O(1)
    public static class Task46
    {
        public static int FastMultiplyBy7(int value)
        {
            return (value << 3) - value;
        }
    }
}