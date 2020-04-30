using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Helpers
{
    public static class ArgumentGuard
    {
        public static void NotNull<T>(T argument, string argumentName)
            where T: class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, $"{argumentName} can not be null");
            }
        }

        public static void NotDefault<T>(T argument, string argumentName)
            where T: struct
        {
            if (argument.Equals(default(T)))
            {
                throw new ArgumentException($"{argumentName} can not be default", argumentName);
            }
        }

        public static void NotNullOrDefault<T>(T? argument, string argumentName)
            where T: struct
        {
            if (!argument.HasValue || argument.Equals(default(T)))
            {
                throw new ArgumentException($"{argumentName} can not be null or default", argumentName);
            }
        }

        public static void NotEmpty(Guid argument, string argumentName)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentException($"'{argumentName}' cannot be an empty Guid");
            }
        }

        public static void NotNullOrWhiteSpace(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException($"'{argumentName}' cannot be null or empty");
            }
        }
    }
}
