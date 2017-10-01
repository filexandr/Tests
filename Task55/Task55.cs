namespace Task55
{
    // 55. Given a sequence of characters.How will you convert the lower case characters to upper case
    // characters. (Try using bit vector).
    // Time: O(n)
    // Space: O(1)
    public static class Task55
    {
        public static void ToUpper(char[] input)
        {
            if (input == null || input.Length == 0) return;

            for (int i = 0; i < input.Length; i++)
            {
                var value = input[i];

                if (value >= 'a' && value <= 'z')
                {
                    var intValue = (int) input[i];
                    intValue += 'A' - 'a';
                    input[i] = (char)intValue;
                }
                else if (value >= 'а' && value <= 'я')
                {
                    var intValue = (int) input[i];
                    intValue += 'А' - 'а';
                    input[i] = (char)intValue;
                }
            }            
        }
    }
}