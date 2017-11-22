using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Check()
        {
            DiagonalMatrix<int> m1 = new DiagonalMatrix<int>(3);
            E e = new E();
            e.Register(m1);
            m1[0, 0] = 1;
            m1[1, 1] = 3;
            m1[2, 2] = 4;
            Console.WriteLine(m1);
        }

        class E
        {
            private void ShowEvent(object sender, ElementChangedEventArgs<int> eventArgs)
            {
                Console.WriteLine($"i: {eventArgs.I}, j: {eventArgs.J}, value: {eventArgs.Value}");
            }

            public void Register(DiagonalMatrix<int> m)
            {
                m.ElementChanged += ShowEvent;
            }

            public void Unregister(DiagonalMatrix<int> m)
            {
                m.ElementChanged -= ShowEvent;
            }
        }
    }
}
