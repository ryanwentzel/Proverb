using System;

namespace Proverb
{
    public static class Ensure
    {
        public static void ArgumentNotNull(object value, string parameterName)
        {
            if (value != null) return;

            throw new ArgumentNullException(parameterName);
        }

        public static void ArgumentNotNullOrEmpty(string value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (value.Trim() == "")
            {
                throw new ArgumentException("Value cannot be empty.", parameterName);
            }
        }
    }
}
