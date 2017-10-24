using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Smocks;
using Smocks.Matching;

namespace Task65
{
    [TestClass]
    public class Task65UnitTest
    {
        private void ExecuteAndCheckResult(Node input, bool positive)
        {
            int currentValue = 0;
            Smock.Run(context  =>
            {
                context.Setup(() => Console.Write(It.IsAny<string>()))
                    .Callback<string>(text =>
                    {
                        //if (!positive) throw new Exception($"Print is not expected but was written '{text}'.");

                        var value = int.Parse(text.Trim());
                        if (value != currentValue + 1)
                            throw new Exception($"Printed not in right order, value: {value}, prev: {currentValue}");
                        currentValue = value;
                    });

                Task65.PrintReverse(input);
                if (positive && currentValue == 0) throw new Exception("No output when expected.");
            });
        }

        [TestMethod]
        public void Null()
        {
            ExecuteAndCheckResult(null, false);
        }

        [TestMethod]
        public void One()
        {
            ExecuteAndCheckResult(new Node(1), true);
        }

        [TestMethod]
        public void Several()
        {
            var list = new Node(3);
            list.CreateNext(2).CreateNext(1);
            ExecuteAndCheckResult(list, true);
        }
    }
}