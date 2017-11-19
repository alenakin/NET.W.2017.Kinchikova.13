using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class QueueEnumerator<T> : IEnumerator<T>
    {
        private T[] values;
        private int size;
        private int iteratorPointer = -1;
        private Queue queue;

        public QueueEnumerator(T[] values, int size)
        {
            this.values = values;
            this.size = size;
        }

        public T Current
        {
            get
            {
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

        public void Dispose() { }

        public bool MoveNext()
        {
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
            iteratorPointer = -1;
        }
    }
}
