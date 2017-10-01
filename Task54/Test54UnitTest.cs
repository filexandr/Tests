using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FluentAssertions;

namespace Task54
{
    [TestClass]
    public class Test54UnitTest
    {
        [TestMethod]
        public void EmptyAndOneElement()
        {
            // Should not raise an exception
            Task54.Shuffle(null); 
            Task54.Shuffle(new int[0]);

            var input = new int[1] {1};
            Task54.Shuffle(input);
            input[0].Should().Be(1);
        }

        [TestMethod]
        public void Test()
        {
            var sessions = new int [10][];

            // Creation
            for (int i = 0; i < sessions.Length; i++)
            {
                sessions[i] = Enumerable.Range(0, 100).ToArray();
                Task54.Shuffle(sessions[i]);
            }

            // Shuffle
            for (int i = 0; i < sessions.Length; i++)
            {
                Task54.Shuffle(sessions[i]);
            }

            // Comparison
            for (int i = 0; i < sessions.Length - 1; i++)
            {
                for (int j = i + 1; j < sessions.Length; j++)
                {
                    sessions[i].Should().NotEqual(sessions[j]);
                }
            }
        }
    }
}