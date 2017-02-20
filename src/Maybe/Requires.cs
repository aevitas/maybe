using System;

namespace Maybe
{
    public static class Requires
    {
        /// <summary>
        ///     Requires the specified value to be non-null, and throws an <see cref="ArgumentNullException" /> if it fails.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void NotNull<T>(T value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        ///     Requires the specified string to be non-empty, and throws a <see cref="ArgumentNullException" /> if it fails.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static void NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(parameterName);
        }
    }
}
