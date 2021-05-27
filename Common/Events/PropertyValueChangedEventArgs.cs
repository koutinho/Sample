using System;

namespace Common
{
    public class PropertyValueChangedEventArgs<T> : EventArgs
    {
        /// <summary></summary>
        /// <param name="propertyName">Имя измененного свойства</param>
        /// <param name="oldValue">Предыдущее значение</param>
        /// <param name="newValue">Записанное значение</param>
        public PropertyValueChangedEventArgs(string parameterName, T oldValue, T newValue)
        {
            ParameterName = parameterName;
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Имя параметра
        /// </summary>
        public string ParameterName { set; get; }

        /// <summary>
        /// Предыдущее значение свойства
        /// </summary>
        public T OldValue { set; get; }

        /// <summary>
        /// Новое значение свойства
        /// </summary>
        public T NewValue { set; get; }
    }
}