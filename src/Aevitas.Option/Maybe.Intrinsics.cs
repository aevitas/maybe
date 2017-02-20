using System;

namespace Aevitas.Option
{
    public static class Maybe
    {
        /// <summary>
        ///     Returns an instance of Maybe for the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Maybe.NoValue if the specified value is null, otherwise a Maybe instance containing the specified value.</returns>
        public static Maybe<T> OfNullableReference<T>(T value) where T : class
        {
            return value == null ? Maybe<T>.NoValue : new Maybe<T>(value);
        }

        /// <summary>
        ///     Returns an instance of Maybe containing the specified value type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Maybe<T> OfValueType<T>(T? value) where T : struct
        {
            return value.HasValue ? new Maybe<T>(value.Value) : Maybe<T>.NoValue;
        }

        /// <summary>
        ///     Returns an instance of Maybe containing the specified value type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        // This overload solely exists to allow the compiler to infer the type param on OfValueType<T> calls.
        public static Maybe<T> OfValueType<T>(T value) where T : struct => new Maybe<T>(value);

        /// <summary>
        ///     Returns an instance of Maybe for the specified non-null reference type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Thrown if the specified value is null.</exception>
        /// <returns>A maybe instance containing the specified value.</returns>
        public static Maybe<T> Of<T>(T value) where T : class
        {
            Requires.NotNull(value, nameof(value));

            return new Maybe<T>(value);
        }
    }
}
