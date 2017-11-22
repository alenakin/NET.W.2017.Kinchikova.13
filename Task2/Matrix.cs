using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class Matrix<T>
    {
        public Matrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(size)} must be greater than zero.");
            }

            Size = size;
        }

        public int Size { get; protected set; }

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            EventHandler<ElementChangedEventArgs<T>> temp = ElementChanged;
            temp?.Invoke(this, e);
        }

        public T this[int firstIdx, int secondIdx]
        {
            get
            {
                IndexesValidation(firstIdx, secondIdx);
                return getValue(firstIdx, secondIdx);
            }
            set
            {
                IndexesValidation(firstIdx, secondIdx);
                setValue(firstIdx, secondIdx, value);
                OnElementChanged(new ElementChangedEventArgs<T>(firstIdx, secondIdx, value));
            }
        }

        protected abstract T getValue(int firstIdx, int secondIdx);

        protected abstract void setValue(int firstIdx, int secondIdx, T value);

        private void IndexesValidation(int firstIdx, int secondIdx)
        {
            if (firstIdx < 0 || secondIdx < 0
                    || firstIdx >= Size || secondIdx >= Size)
            {
                throw new ArgumentOutOfRangeException("Indexes must be in range [0; size of matrix).");
            }
        }
    }
}
