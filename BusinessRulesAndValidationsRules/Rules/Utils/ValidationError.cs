﻿using BusinessRulesAndValidationsRules.Rules.Validator;

namespace BusinessRulesAndValidationsRules.Rules.Utils
{
    /// <summary>
    /// Represents a validation error from a <see cref="IEntityValidator{TEntity}.Validate"/> method
    /// call.
    /// </summary>
    public struct ValidationError
    {
        #region fields
        public readonly string Message;
        public readonly string Property;
        #endregion

        #region ctor
        /// <summary>
        /// Default Constructor.
        /// Creates a new instance of the <see cref="ValidationError"/> data structure.
        /// </summary>
        /// <param name="message">string. The validation error message.</param>
        /// <param name="property">string. The property that was validated.</param>
        public ValidationError(string message, string property)
        {
            //Guard.Against<ArgumentNullException>(string.IsNullOrEmpty("message"), "Please provide a valid non null string as the validation error message");
            //Guard.Against<ArgumentNullException>(string.IsNullOrEmpty("property"), "Please provide a valid non null string as the validation property name");
            Message = message;
            Property = property;
        }
        #endregion

        #region methods
        /// <summary>
        /// Overriden. Gets a string that represents the validation error.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0}) - {1}", Property, Message);
        }

        /// <summary>
        /// Overridden. Compares if an object is equal to the <see cref="ValidationError"/> instance.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ValidationError)) return false;
            return Equals((ValidationError)obj);
        }

        /// <summary>
        /// Overriden. Compares if a <see cref="ValidationError"/> instance is equal to this
        /// <see cref="ValidationError"/> instance.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(ValidationError obj)
        {
            return Equals(obj.Message, Message) && Equals(obj.Property, Property);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                return Message.GetHashCode() * 397 ^ Property.GetHashCode();
            }
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValidationError left, ValidationError right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValidationError left, ValidationError right)
        {
            return !left.Equals(right);
        }
        #endregion
    }
}