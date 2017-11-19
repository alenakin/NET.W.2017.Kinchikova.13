using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] values;
        private const int defaultCapacity = 16;
        private int size = 0;
        private int head = 0;
        private int tail = 0;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Queue()
        {
            values = new T[defaultCapacity];
        }

        /// <summary>
        /// Constructor which creates queue of specified size.
        /// </summary>
        /// <param name="size">Size of new queue.</param>
        /// <exception cref="ArgumentOutOfRangeException">size < zero.</exception>
        public Queue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than 0");
            }

            values = new T[size];
        }

        public int Capacity { get { return this.values.Length;  } }

        public void Enqueue(T value)
        {
            if (size == Capacity)
            {
                Array.Resize(ref values, Capacity * 2);
            }
            
            values[tail++ % Capacity] = value;
            size++;
        }

        public T Dequeue()
        {
            size--;
            return values[head++ % Capacity];
        }

        public T Peek()
        {
            return values[head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(values, size);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new QueueEnumerator<T>(values, size);
        }
    }
}
