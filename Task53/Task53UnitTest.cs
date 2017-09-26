using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Smocks;
using Smocks.Matching;

namespace Task53
{
    [TestClass]
    public class Task53UnitTest
    {
        private void ExecuteAndCheckResult(int[,] input)
        {
            int currentValue = 0;
            Smock.Run(context =>
            {
                context.Setup(() => Console.Write(It.IsAny<string>()))
                    .Callback<string>(text =>
                    {
                        var value = int.Parse(text.Trim());
                        if (value != currentValue + 1)
                            throw new Exception($"Printed not in right order, value: {value}, prev: {currentValue}");
                        currentValue = value;
                    });

                Task53.PrintArrayInSpiralOrder(input);
            });
        }

        [TestMethod]
        public void NullAndEmpty()
        {
            Task53.PrintArrayInSpiralOrder(null);
            Task53.PrintArrayInSpiralOrder(new int[,] {});
        }

        [TestMethod]
        public void Array1X1()
        {
            var input = new int[,]
            {
                {1}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array2X1()
        {
            var input = new int[,]
            {
                {1, 2}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array3X1()
        {
            var input = new int[,]
            {
                {1, 2, 3}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array2X2()
        {
            var input = new int[,]
            {
                {1, 2},
                {4, 3}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array3X2()
        {
            var input = new int[,]
            {
                {1, 2, 3},
                {6, 5, 4}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array2X3()
        {
            var input = new int[,]
            {
                {1, 2},
                {6, 3},
                {5, 4}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array4X2()
        {
            var input = new int[,]
            {
                {1, 2, 3, 4},
                {8, 7, 6, 5}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array3X3()
        {
            var input = new int[,]
            {
                {1, 2, 3},
                {8, 9, 4},
                {7, 6, 5}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array4X3()
        {
            var input = new int[,]
            {
                {1,  2,  3,  4},
                {10, 11, 12, 5},
                {9,  8,  7,  6}
            };

            ExecuteAndCheckResult(input);
        }

        [TestMethod]
        public void Array4X4()
        {
            var input = new int[,]
            {
                {1,  2,  3,  4},
                {12, 13, 14, 5},
                {11, 16, 15, 6},
                {10, 9,  8,  7}
            };

            ExecuteAndCheckResult(input);
        }
    }
}