using System;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string str, string substring, StringComparison comparison)
        {
            if (substring == null)
            {
                throw new ArgumentNullException(nameof(substring), "substring cannot be null.");
            }

            if (!Enum.IsDefined(typeof(StringComparison), comparison))
            {
                throw new ArgumentException("comp is not a member of StringComparison", nameof(comparison));
            }

            return str.IndexOf(substring, comparison) >= 0;
        }
    }
}
