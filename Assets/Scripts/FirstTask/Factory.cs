
using System;

namespace FirstTask
{
    public class Factory<T> where T: ICloneable
    {
        private T _prototype;
        
        public Factory(T prototype)
        {
            _prototype = prototype;
        }

        public T New()
        {
            return (T) _prototype.Clone();
        }
    }
}