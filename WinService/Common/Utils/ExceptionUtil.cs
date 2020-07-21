using System;
using System.Collections.Generic;

namespace Common.Utils
{
    /// <summary>
    /// A helper class to help create standardized exceptions.
    /// </summary>
    public static class ExceptionUtil
    {
        /// <summary>
        /// Create an Exception with the standard error message for a missing
        /// DB row, detailing its primary key.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="idColumnName"></param>
        /// <param name="id"></param>
        /// <param name="contextExplanationSentence"></param>
        /// <returns></returns>
        public static InvalidOperationException CreateMissingDbRowsException(
            string tableName,
            object obj,
            string contextExplanationSentence = null
        )
        {
            var idDeclaration = ConvertObjectToIdDeclaration(obj);

            var baseMessage = $"Could not find {tableName} rows with {idDeclaration}.";

            string fullMessage;

            if (contextExplanationSentence == null)
            {
                fullMessage = baseMessage;
            }
            else
            {
                fullMessage = $"{contextExplanationSentence} {baseMessage}";
            }

            return new InvalidOperationException(fullMessage);
        }

        /// <summary>
        /// Create an Exception with the standard error message for a missing
        /// DB row, detailing its primary key.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="idColumnName"></param>
        /// <param name="id"></param>
        /// <param name="contextExplanationSentence"></param>
        /// <returns></returns>
        public static InvalidOperationException CreateMissingDbRowException(
            string tableName,
            string idColumnName,
            string id,
            string contextExplanationSentence = null
        )
        {
            var baseMessage = $"Could not find {tableName} row with {idColumnName} of '{id}'.";

            string fullMessage;

            if (contextExplanationSentence == null)
            {
                fullMessage = baseMessage;
            }
            else
            {
                fullMessage = $"{contextExplanationSentence} {baseMessage}";
            }

            return new InvalidOperationException(fullMessage);
        }

        /// <summary>
        /// Create an Exception with the standard error message for a DB row
        /// with a missing column, detailing its primary key and the missing
        /// column's name.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="idColumnName"></param>
        /// <param name="id"></param>
        /// <param name="contextExplanationSentence"></param>
        /// <returns></returns>
        public static InvalidOperationException CreateEmptyColumnException(
            string tableName, 
            string idColumnName, 
            string id, 
            string missingColumnName,
            string contextExplanationSentence = null
        )
        {
            var baseMessage = $"Found row for {tableName} with {idColumnName} of '{id}' but the column {missingColumnName} is empty.";
            string fullMessage;

            if (contextExplanationSentence == null)
            {
                fullMessage = baseMessage;
            }
            else
            {
                fullMessage = $"{contextExplanationSentence} {baseMessage}";
            }

            return new InvalidOperationException(fullMessage);
        }

        public static ArgumentException ParameterMustBeGreaterThan(string parameterName, int minimum)
        {
            return new ArgumentException($"The parameter '{parameterName}' must be greater than {minimum}.");
        }

        private static string ConvertObjectToIdDeclaration(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            var props = obj.GetType().GetProperties();

            var declarations = new List<string>();

            foreach(var prop in props)
            {
                declarations.Add($"{prop.Name} '{prop.GetValue(obj)}'");
            }

            return string.Join(", ", declarations);
        }

    }
}
