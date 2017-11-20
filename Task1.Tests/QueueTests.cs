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
        private static int[] arr = GenerateArray(18);

        private static object[] elementsSource =
        {
            new object[] { new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 } },
            new object[] { arr, arr }
        };

        private static object[] elementsDeleteSource =
        {
            new object[] { new int[] { 1, 2, 3 }, 1, new int[] { 2, 3 } },
            new object[] { new int[] { 1, 2, 3 }, 2, new int[] { 3 } },
            new object[] { new int[] { 1, 2, 3, }, 3, new int[] { } }
        };

        [TestCaseSource("elementsSource")]
        public void Enqueue_IntElements_EqualToResult(int[] source, int[] result)
        {
            var queue = new CustomQueue<int>();
            for (int i = 0; i < source.Length; i++)
            {
                queue.Enqueue(source[i]);
            }
            
            CollectionAssert.AreEqual(result, queue.ToArray());
        }

        [TestCaseSource("elementsDeleteSource")]
        public void Dequeue_DeleteElements_EqualToResult(int[] source, int numDeleted, int[] result)
        {
            var queue = new CustomQueue<int>();
            for (int i = 0; i < source.Length; i++)
            {
                queue.Enqueue(source[i]);
            }

            for (int i = 0; i < numDeleted; i++)
            {
                Console.Write(queue.Dequeue() + " ");
            }

            CollectionAssert.AreEqual(result, queue.ToArray());
        }

        [Test]
        public void GetEnumerator_TryToChangeCollection_InvalidOperationException()
        {
            var queue = new CustomQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (int i in queue)
                {
                    queue.Dequeue();
                }
            });
        }

        [Test]
        public void Dequeue_EmptyQueue_InvalidOperationException()
        {
            var queue = new CustomQueue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        private static int[] GenerateArray(int n)
        {
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rnd.Next();
            }

            return array;
        }
    }
}
