using System;

namespace Common.Interfaces
{
    public interface ITimeZoneSelectionContainer 
    {
        /// <summary>
        /// Временная зона, в которую надо пересчитывать значения даты и времени
        /// </summary>
        TimeZoneInfo CurrentTimeZoneInfo { get; }

        /// <summary>
        /// Временная зона текущего выбранного устройства (объекта, в котором устройство установлено)
        /// </summary>
        TimeZoneInfo ObjectTimeZoneInfo { get; }

        /// <summary>
        /// Устанавливает значение текущей временной зоны
        /// </summary>
        void SetCurrentTimeZoneInfo(TimeZoneInfo timeZoneInfo);

        /// <summary>
        /// Устанавливает значение текущей временной зоны по текстовому идентификатору
        /// </summary>
        void SetCurrentTimeZoneInfo(string timeZoneId);

        /// <summary>
        /// Устанавливает значение временной зоны объекта
        /// </summary>
        void SetObjectTimeZoneInfo(TimeZoneInfo timeZoneInfo);

        /// <summary>
        /// Устанавливает значение временной зоны объекта по текстовому идентификатору
        /// </summary>
        void SetObjectTimeZoneInfo(string timeZoneId);

        /// <summary>
        /// Событие изменения текущей временной зоны
        /// </summary>
        event EventHandler CurrentTimeZoneChanged;

        /// <summary>
        /// Событие изменения временной зоны объекта
        /// </summary>
        event EventHandler ObjectTimeZoneChanged;
    }
}
