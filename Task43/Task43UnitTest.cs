using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task43
{
    [TestClass]
    public class Task43UnitTest
    {
        [TestMethod]
        public void RotateLeft()
        {
            var arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateLeft(arr, 0, arr.Length - 1, 0);
            arr.Should().Equal(new[] {'a', 'b', 'c', 'd'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateLeft(arr, 0, arr.Length - 1, 1);
            arr.Should().Equal(new[] {'b', 'c', 'd', 'a'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateLeft(arr, 0, arr.Length - 1, 2);
            arr.Should().Equal(new[] {'c', 'd', 'a', 'b'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateLeft(arr, 0, arr.Length - 1, 3);
            arr.Should().Equal(new[] {'d', 'a', 'b', 'c'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateLeft(arr, 0, arr.Length - 1, 4);
            arr.Should().Equal(new[] {'a', 'b', 'c', 'd'});

            arr = new[] {'a', 'b', 'c', 'd', 'e'};
            Task43.RotateLeft(arr, 1, 3, 1);
            arr.Should().Equal(new[] {'a', 'c', 'd', 'b', 'e'});
        }

        [TestMethod]
        public void RotateRight()
        {
            var arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateRight(arr, 0, arr.Length - 1, 0);
            arr.Should().Equal(new[] {'a', 'b', 'c', 'd'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateRight(arr, 0, arr.Length - 1, 1);
            arr.Should().Equal(new[] {'d', 'a', 'b', 'c'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateRight(arr, 0, arr.Length - 1, 2);
            arr.Should().Equal(new[] {'c', 'd', 'a', 'b'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateRight(arr, 0, arr.Length - 1, 3);
            arr.Should().Equal(new[] {'b', 'c', 'd', 'a'});

            arr = new[] {'a', 'b', 'c', 'd'};
            Task43.RotateRight(arr, 0, arr.Length - 1, 4);
            arr.Should().Equal(new[] {'a', 'b', 'c', 'd'});

            arr = new[] {'a', 'b', 'c', 'd', 'e'};
            Task43.RotateRight(arr, 1, 3, 1);
            arr.Should().Equal(new[] {'a', 'd', 'b', 'c', 'e'});
        }

        [TestMethod]
        public void SentanceNullAndEmpty()
        {
            Task43.ReverseWords(null);
            Task43.ReverseWords(new char[0]);
        }

        [TestMethod]
        public void SentanceNoOrOneWord()
        {
            var sentance = " ".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal(" ");

            sentance = "  ".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal("  ");

            sentance = "   ".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal("   ");

            sentance = "a  ".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal("a  ");

            sentance = " ab ".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal(" ab ");

            sentance = " abc".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal(" abc");
        }

        [TestMethod]
        public void SentanceSeveralWords()
        {
            var sentance = "hello  bye ".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal("bye  hello ");

            sentance = "  hello my   dear ".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal("  dear my   hello ");
            Task43.ReverseWords(sentance);
            sentance.Should().Equal("  hello my   dear ");

            sentance = "1 2 3 4 5 6".ToCharArray();
            Task43.ReverseWords(sentance);
            sentance.Should().Equal("6 5 4 3 2 1");
        }
    }
}