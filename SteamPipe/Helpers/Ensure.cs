using System;

namespace SteamPipe.Helpers
{
    internal static class Ensure
    {
        public static void ArgumentNotNull([ValidatedNotNull] object value, string name)
        {
            if (value != null) return;

            throw new ArgumentNullException(name);
        }

        public static void ArgumentNotNullOrEmptyString([ValidatedNotNull] string value, string name)
        {
            ArgumentNotNull(value, name);
            if (!string.IsNullOrWhiteSpace(value)) return;

            throw new ArgumentException("String cannot be empty");
        }

        public static void ArgumentNotZero(int value, string name)
        {
            if (value != 0) return;

            throw new ArgumentException("Int cannot be zero");
        }

        [AttributeUsage(AttributeTargets.Parameter)]
        internal sealed class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}