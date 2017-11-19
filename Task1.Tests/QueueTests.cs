using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Check()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            foreach(int a in q)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }
    }
}
