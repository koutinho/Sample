using System;

namespace Common.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Дает возможность проверять переменную любого типа на null при помощи синтаксиса "?."
        /// перед выполнением какой-либо операции, не являющейся методом, доступным через эту переменную.
        /// </summary>
        /// <remarks>
        /// Позволяет вместо:
        ///     if (someVar != null)
        ///         result = SomeFunc(someVar);
        ///     else
        ///         result = null;
        /// или
        ///     result = someVar != null ? SomeFunc(someVar) : null;
        /// писать:
        ///     result = someVar?.Do(() => SomeFunc(someVar));
        /// 
        /// Есть возможность выполнять составные операции:
        ///     result = someVar?.Do(() =>
        ///     {
        ///         var temp = SomeFunc1(someVar);
        ///         return SomeFunc2(temp);
        ///     }
        /// </remarks>
        /// <typeparam name="ArgumentType">Тип проверяемой переменной</typeparam>
        /// <typeparam name="ResultType">Тип результата выполнения операции</typeparam>
        /// <param name="argument">Проверяемая переменная</param>
        /// <param name="function">Выполняемая операция</param>
        /// <returns>Результат выполнения операции function/></returns>
        public static ResultType Do<ArgumentType, ResultType>(this ArgumentType argument, Func<ResultType> function) => function();

        /// <summary>
        /// Проверка на то, что тип является числовым.
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public static bool IsNumericType(this object _object)
        {
            switch (Type.GetTypeCode(_object.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;

                default:
                    return false;
            }
        }
    }
}
