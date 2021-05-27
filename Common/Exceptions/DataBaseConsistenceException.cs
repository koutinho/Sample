using System;

namespace Common.Exceptions
{
    /// <summary>
    /// Исключение сообщающее о неконсистентности данных в БД
    /// </summary>
    public class DataBaseConsistenceException:Exception
    {
        /// <summary>
        /// Выполняет инициализацию нового экземпляра класса Common.Exceptions.DataBaseConsistenceException, используя
        /// указанное сообщение об ошибке.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public DataBaseConsistenceException(string message) : base(message)
        { }
    }
}
