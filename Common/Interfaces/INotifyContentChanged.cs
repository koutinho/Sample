using System;

namespace Common.Interfaces
{
    public interface INotifyContentChanged
    {
        event EventHandler ContentChanged;
    }
}
