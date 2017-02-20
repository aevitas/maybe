using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Maybe
{
    /// <summary>
    ///     Represents an option type.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebugDisplay) + "}")]
    public struct Maybe<T> : IEquatable<Maybe<T>>
    {
        private readonly T _value;

        /// <summary>
        ///     Gets a value indicating whether this option type has value.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </value>
        public bool HasValue { get; }

        /// <summary>
        ///     Gets the value if this instance contains any, otherwise, throws an <see cref="InvalidOperationException" />.
        /// </summary>
        public T Value
        {
            get
            {
                // This violated the design guideline that properties should be safe to "get".
                // Reason being is that, if this instance has no value, this property can not return anything meaningful whatsoever.
                // The whole point of an option type is to not return null, ergo throwing here is the only viable option.
                if (!HasValue)
                    throw new InvalidOperationException("Can not retrieve the value of a Maybe<T> that has no value!");

                return _value;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Maybe{T}" /> struct.
        /// </summary>
        /// <param name="value">The value.</param>
        public Maybe(T value)
        {
            Requires.NotNull(value, nameof(value));

            _value = value;
            HasValue = true;
        }

        /// <summary>
        ///     Returns an option type containing the specified type, containing no value.
        /// </summary>
        public static Maybe<T> NoValue => default(Maybe<T>);

        #region Implementation of IEquatable<Maybe<T>>

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(_value) * 397) ^ HasValue.GetHashCode();
            }
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Maybe<T> other)
        {
            return EqualityComparer<T>.Default.Equals(_value, other._value) && HasValue == other.HasValue;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Maybe<T> && Equals((Maybe<T>)obj);
        }

        #endregion

        public static bool operator ==(Maybe<T> left, Maybe<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Maybe<T> left, Maybe<T> right)
        {
            return !left.Equals(right);
        }

        private string DebugDisplay => HasValue ? "Maybe: " + Value : "Maybe.NoValue";
    }
}
