using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Represents a first-in, first-out custom collection of objects.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        #region Fields
        private const int DefaultCapacity = 16;
        private T[] values;
        private int count = 0;
        private int head = 0;
        private int tail = 0;
        private int version = 0;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomQueue()
        {
            values = new T[DefaultCapacity];
        }

        /// <summary>
        /// Constructor which creates queue of specified size.
        /// </summary>
        /// <param name="size">Size of new queue.</param>
        /// <exception cref="ArgumentOutOfRangeException">size < zero.</exception>
        public CustomQueue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than 0");
            }

            values = new T[size];
        }
        #endregion 

        /// <summary>
        /// Gets the number of elements contained in the CustomQueue.
        /// </summary>
        public int Count { get => this.count; }

        private int Capacity { get => this.values.Length; }

        /// <summary>
        /// Adds an object to the end of the CustomQueue.
        /// </summary>
        /// <param name="value">The object to add.</param>
        public void Enqueue(T value)
        {
            if (count == Capacity)
            {
                Array.Resize(ref values, Capacity * 2);
            }
            
            values[tail++ % Capacity] = value;
            count++;
            version++;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the CustomQueue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        /// <returns>The object at the beginning of the CustomQueue.</returns>
        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            count--;
            version++;
            return values[head++ % Capacity];
        }

        /// <summary>
        /// Returns the object at the beginning of the CustomQueue without removing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        /// <returns>The object at the beginning of the CustomQueue.</returns>
        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return values[head];
        }

        /// <summary>
        /// Copies the CustomQueue elements to a new array.
        /// </summary>
        /// <returns>Array with CustomQueue elements.</returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];
            if (tail >= head)
            {
                Array.Copy(values, head, array, 0, Count);
            }
            else
            {
                int firstPortionLength = Capacity - head;
                Array.Copy(values, head, array, 0, firstPortionLength);
                Array.Copy(values, 0, array, 0, Count - firstPortionLength);
            }

            return array;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the CustomQueue.
        /// </summary>
        /// <returns>Enumerator that iterates through the CustomQueue.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        public struct QueueEnumerator : IEnumerator<T>
        {
            private T[] values;
            private int size;
            private int iteratorPointer;
            private int version;
            private CustomQueue<T> queue;

            public QueueEnumerator(CustomQueue<T> queue)
            {
                this.queue = queue;
                this.values = queue.values;
                this.size = queue.count;
                this.version = queue.version;
                this.iteratorPointer = -1;
            }

            public T Current
            {
                get
                {
                    if (this.version != queue.version)
                    {
                        throw new InvalidOperationException();
                    }

                    if (iteratorPointer != -1)
                    {
                        return values[iteratorPointer];
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (this.version != queue.version)
                {
                    throw new InvalidOperationException();
                }

                if (iteratorPointer < size - 1)
                {
                    iteratorPointer++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                if (this.version != queue.version)
                {
                    throw new InvalidOperationException();
                }

                iteratorPointer = -1;
            }
        }
    }
}
