using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Smocks;
using Smocks.Matching;

namespace Task66
{
    [TestClass]
    public class Task66UnitTest
    {
        public enum PrintOrder
        {
            PreOrder,
            InOrder,
            PostOrder
        }

        private void ExecuteAndCheckResult(BinaryTreeNode input, PrintOrder order, bool positive)
        {
            int currentValue = 0;
            Smock.Run(context  =>
            {
                context.Setup(() => Console.Write(It.IsAny<string>()))
                    .Callback<string>(text =>
                    {
                        if (!positive) throw new Exception($"Print is not expected but was written '{text}'.");
                        var value = int.Parse(text.Trim());
                        if (value != currentValue + 1)
                            throw new Exception($"Printed not in right order, value: {value}, prev: {currentValue}");
                        currentValue = value;
                    });

                switch (order)
                {
                        case PrintOrder.PreOrder: Task66.PrintPreOrder(input); break;
                        case PrintOrder.InOrder: Task66.PrintInOrder(input); break;
                        case PrintOrder.PostOrder: Task66.PrintPostOrder(input); break;
                }

                if (positive && currentValue == 0) throw new Exception("No output when expected.");
            });
        }

        [TestMethod]
        public void Null()
        {
            ExecuteAndCheckResult(null, PrintOrder.PreOrder, false);
            ExecuteAndCheckResult(null, PrintOrder.InOrder, false);
            ExecuteAndCheckResult(null, PrintOrder.PostOrder, false);
        }

        [TestMethod]
        public void One()
        {
            ExecuteAndCheckResult(new BinaryTreeNode(1), PrintOrder.PreOrder, true);
            ExecuteAndCheckResult(new BinaryTreeNode(1), PrintOrder.InOrder, true);
            ExecuteAndCheckResult(new BinaryTreeNode(1), PrintOrder.PostOrder, true);
        }

        [TestMethod]
        public void Several()
        {
            var tree = new BinaryTreeNode(2);
            tree.CreateLeftNode(1);
            tree.CreateRightNode(3);
            ExecuteAndCheckResult(tree, PrintOrder.InOrder, true);

            tree = new BinaryTreeNode(1);
            tree.CreateLeftNode(2);
            tree.CreateRightNode(3);
            ExecuteAndCheckResult(tree, PrintOrder.PreOrder, true);

            tree = new BinaryTreeNode(3);
            tree.CreateLeftNode(1);
            tree.CreateRightNode(2);
            ExecuteAndCheckResult(tree, PrintOrder.PostOrder, true);
        }
    }
}