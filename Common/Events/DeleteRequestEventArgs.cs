using System;

namespace Common
{
    public class DeleteRequestEventArgs<T> : EventArgs
    {
        public DeleteRequestEventArgs(T @object)
        {
            Object = @object;
        }

        public T Object
        {
            get;
            set;
        }
    }
}
