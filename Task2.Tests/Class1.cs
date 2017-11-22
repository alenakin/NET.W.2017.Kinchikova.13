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
            Matrix<int> m1 = new DiagonalMatrix<int>(3);
            E<int> e = new E<int>();
            e.Register(m1);
            m1[0, 0] = 1;
            m1[1, 1] = 3;
            m1[2, 2] = 4;
            Console.WriteLine(m1);

            E<string> e1 = new E<string>();
            Matrix<string> s1 = new SymmetricMatrix<string>(2);
            e1.Register(s1);
            s1[0, 1] = "asd";
            s1[1, 1] = "qas";
            Console.WriteLine(s1);
            
        }

        class E<T>
        {
            private void ShowEvent(object sender, ElementChangedEventArgs<T> eventArgs)
            {
                Console.WriteLine($"i: {eventArgs.I}, j: {eventArgs.J}, value: {eventArgs.Value}");
            }

            public void Register(Matrix<T> m)
            {
                m.ElementChanged += ShowEvent;
            }

            public void Unregister(Matrix<T> m)
            {
                m.ElementChanged -= ShowEvent;
            }
        }
    }
}
