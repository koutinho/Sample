using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.StringUtilities
{
    public static class StringUtilities
    {
        /// <summary>
        /// Функция проверяет строку на соотвествие формату IP адреса
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>текст ошибки или null если строка корректна</returns>
        public static string ValidateIPAddress(string _value)
        {
            if (!String.IsNullOrWhiteSpace(_value))
            {
                string[] addressParts = _value.Split('.');

                if (addressParts.Length != 4)
                {
                    return "Не соответствует формату 255.255.255.255";
                }

                foreach (string addressPart in addressParts)
                {
                    int intValue;
                    var parsed = int.TryParse(addressPart, out intValue);
                    if (!parsed || intValue < 0 || intValue > 255)
                    {
                        return "Значение вне диапазона 0 – 255"; //Тире Alt+0150
                    }
                }
            }

            return null;
        }
    }
}
