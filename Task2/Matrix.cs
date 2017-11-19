using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class Matrix<T>
    {
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate { };

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            EventHandler<ElementChangedEventArgs<T>> temp = ElementChanged;
            temp?.Invoke(this, e);
        }
    }
}
