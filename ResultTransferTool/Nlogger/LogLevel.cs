using System;

namespace Nlogger
{
    public sealed class LogLevel : IComparable, IEquatable<LogLevel>
    {
        public static readonly LogLevel Trace = new LogLevel("Trace", 0);
        public static readonly LogLevel Debug = new LogLevel("Debug", 1);
        public static readonly LogLevel Info = new LogLevel("Info", 2);
        public static readonly LogLevel Warn = new LogLevel("Warn", 3);
        public static readonly LogLevel Error = new LogLevel("Error", 4);
        public static readonly LogLevel Fatal = new LogLevel("Fatal", 5);
        public static readonly LogLevel Off = new LogLevel("Off", 6);

        private LogLevel(string name, int ordinal)
        {
            Ordinal = ordinal;
            Name = name;
        }

        public string Name { get; }

        public int Ordinal { get; }

        internal static LogLevel MaxLevel => Fatal;

        internal static LogLevel MinLevel => Trace;
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            var level = (LogLevel)obj;
            return Ordinal - level.Ordinal;
        }

        public bool Equals(LogLevel other)
        {
            return other != null && Ordinal == other.Ordinal;
        }

        public override int GetHashCode()
        {
            return Ordinal;
        }

        public override bool Equals(object obj)
        {
            var other = obj as LogLevel;
            if ((object)other == null)
            {
                return false;
            }
            return Ordinal == other.Ordinal;
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(LogLevel level1, LogLevel level2)
        {
            if (ReferenceEquals(level1, null))
            {
                return ReferenceEquals(level2, null);
            }

            if (ReferenceEquals(level2, null))
            {
                return false;
            }

            return level1.Ordinal == level2.Ordinal;
        }

        public static bool operator !=(LogLevel level1, LogLevel level2)
        {
            if (ReferenceEquals(level1, null))
            {
                return !ReferenceEquals(level2, null);
            }

            if (ReferenceEquals(level2, null))
            {
                return true;
            }

            return level1.Ordinal != level2.Ordinal;
        }

        public static bool operator >(LogLevel level1, LogLevel level2)
        {
            AssertNotNull(level1);
            AssertNotNull(level2);
            return level1.Ordinal > level2.Ordinal;
        }

        private static void AssertNotNull(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public static bool operator <(LogLevel level1, LogLevel level2)
        {
            AssertNotNull(level1);
            AssertNotNull(level2);
            return level1.Ordinal < level2.Ordinal;
        }

        public static bool operator >=(LogLevel level1, LogLevel level2)
        {
            AssertNotNull(level1);
            AssertNotNull(level2);
            return level1.Ordinal >= level2.Ordinal;
        }

        public static bool operator <=(LogLevel level1, LogLevel level2)
        {
            AssertNotNull(level1);
            AssertNotNull(level2);
            return level1.Ordinal <= level2.Ordinal;
        }
    }
}
