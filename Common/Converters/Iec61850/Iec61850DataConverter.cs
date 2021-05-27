using System;

namespace Common.Converters.Iec61850
{
    public static class Iec61850DataConverter
    {
        /// <summary>        
        /// Согласно IEC61850-7-3 раздел 6.2, младшие 2 бита поля Quality задают обобщеное значение качества сигнала - validity:
        /// 0 - good, 1 - invalid, 2 - reserved, 3 - questionable
        /// Последовательность бит обратная и последовательность байт обратная.  
        /// </summary>
        /// <returns>Значение Validity</returns>
        public static byte SpsQualityToValidity(UInt16 quality)
        {
            return (byte)((quality & 0xC0) >> 6);
        }

        /// <summary>
        /// Возращает тектовое представления поля Validity значения Quality типа SPS огласно IEC61850-7-3 раздел 6.2.
        /// </summary>
        /// <param name="quality">Значение Quality тпа SPS огласно IEC61850-7-3 раздел 6.2.</param>
        /// <returns>Тектовое представления поля Validity</returns>
        public static string SpsQualityToValidityString(UInt16 quality)
        {
            string qualityString = string.Empty;

            // Validity: 0 - good, 1 - invalid, 2 - reserved, 3 - questionable
            switch (SpsQualityToValidity(quality))
            {
                case 0:
                    qualityString = "Хорошее";
                    break;

                case 1:
                    qualityString = "Недействительное";
                    break;

                case 2:
                    qualityString = "Зарезервированное";
                    break;

                case 3:
                    qualityString = "Сомнительное";
                    break;
            }

            return qualityString;
        }
    }
}
