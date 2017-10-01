namespace Task54
{
    // 54. Write an efficient algorithm to shuffle a pack of cards this one was a feedback process until we
    // came up with one with no extra storage.
    // Time: O(n)
    // Space: O(1)
    public static class Task54
    {
        public static void Shuffle(int[] cards)
        {
            if (cards == null || cards.Length < 2) return;

            var lastIndex = cards.Length - 1;
            for (int i = 0; i < lastIndex; i++)
            {
                var index1 = CustomRandom.Next(0, lastIndex);
                var index2 = CustomRandom.Next(0, lastIndex);
                if (index1 != index2)
                {
                    var old1 = cards[index1];
                    cards[index1] = cards[index2];
                    cards[index2] = old1;
                }
            }
        }
    }
}