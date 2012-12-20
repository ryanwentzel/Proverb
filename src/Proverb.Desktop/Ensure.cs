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
    }
}
