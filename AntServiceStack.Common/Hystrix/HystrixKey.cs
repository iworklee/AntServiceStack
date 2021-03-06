﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntServiceStack.Common.Hystrix
{
    /// <summary>
    /// A base implementation for immutable keys to represent Hystrix objects.
    /// Keys are equal if their types are the same and their names are equal with ordinal string comparison.
    /// </summary>
    public abstract class HystrixKey : IEquatable<HystrixKey>
    {
        /// <summary>
        /// Readonly field to store the name of the key.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="HystrixKey"/> class.
        /// </summary>
        /// <param name="name">The name of the key, can't be null or whitespace.</param>
        protected HystrixKey(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;
        }

        /// <summary>
        /// Gets the name of the key.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Determines whether two specified keys are equal.
        /// </summary>
        /// <param name="left">The first key to compare.</param>
        /// <param name="right">The second key to compare.</param>
        /// <returns>True if the two keys are equal.</returns>
        public static bool operator ==(HystrixKey left, HystrixKey right)
        {
            if (object.ReferenceEquals(left, null))
            {
                return object.ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two specified keys are different.
        /// </summary>
        /// <param name="left">The first key to compare.</param>
        /// <param name="right">The second key to compare.</param>
        /// <returns>True if the two keys are not equal.</returns>
        public static bool operator !=(HystrixKey left, HystrixKey right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="HystrixKey"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            HystrixCommandKey other = obj as HystrixCommandKey;
            return this.Equals(other);
        }

        /// <summary>
        /// Calculates the hash code for this key.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        /// <summary>
        /// Returns the name of the current key.
        /// </summary>
        /// <returns>The name of the command key.</returns>
        public override string ToString()
        {
            return this.name;
        }

        /// <summary>
        /// Determines whether the specified <see cref="HystrixKey"/> is equal to the current <see cref="HystrixKey"/>.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false</returns>
        public bool Equals(HystrixKey other)
        {
            if (object.ReferenceEquals(other, null) || GetType() != other.GetType())
            {
                return false;
            }

            return this.name.Equals(other.name, StringComparison.Ordinal);
        }
    }
}
