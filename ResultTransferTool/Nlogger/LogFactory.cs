using System;
using System.Collections.Generic;
using Nlogger.Exception;

namespace Nlogger
{
    public class LogFactory
    {
        private readonly object _syncRoot = new object();
        private readonly LoggerCache _loggerCache = new LoggerCache();

        public Logger GetLogger(string name)
        {
            return GetLogger(new LoggerCacheKey(name, typeof(Logger)));
        }

        public event Action<LogEventInfo> ReceivedLog;

        protected virtual void OnReceivedLog(LogEventInfo obj)
        {
            ReceivedLog?.Invoke(obj);
        }

        public List<Logger> AllLoggers => _loggerCache.AllCacheValues;

        private Logger GetLogger(LoggerCacheKey cacheKey)
        {
            lock (_syncRoot)
            {
                if (cacheKey.ConcreteType != typeof(Logger))
                {
                    throw new NLoggerRuntimeException("ConcreteType of loggerCacheKey is not 'Logger'");
                }
                var existingLogger = _loggerCache.Retrieve(cacheKey);
                if (existingLogger != null)
                {
                    return existingLogger;
                }
                var newlogger = new Logger { Name = cacheKey.Name };
                _loggerCache.InsertOrUpdate(cacheKey, newlogger);
                newlogger.LogReceived += OnReceivedLog;
                return newlogger;
            }
        }

        internal class LoggerCacheKey : IEquatable<LoggerCacheKey>
        {
            public string Name { get; }
            public Type ConcreteType { get; }

            public override bool Equals(object obj)
            {
                var key = obj as LoggerCacheKey;
                if (ReferenceEquals(key, null))
                {
                    return false;
                }

                return (ConcreteType == key.ConcreteType) && (key.Name == this.Name);
            }

            public bool Equals(LoggerCacheKey key)
            {
                if (ReferenceEquals(key, null))
                {
                    return false;
                }

                return (ConcreteType == key.ConcreteType) && (key.Name == this.Name);
            }

            public LoggerCacheKey(string name, Type concreteType)
            {
                Name = name;
                ConcreteType = concreteType;
            }

            public override int GetHashCode()
            {
                return ConcreteType.GetHashCode() ^ Name.GetHashCode();
            }
        }

        private class LoggerCache
        {
            private readonly Dictionary<LoggerCacheKey, WeakReference> _loggerCache = new Dictionary<LoggerCacheKey, WeakReference>();

            public Logger Retrieve(LoggerCacheKey cacheKey)
            {
                WeakReference loggerReference;
                if (_loggerCache.TryGetValue(cacheKey, out loggerReference))
                {
                    return loggerReference.Target as Logger;
                }
                return null;
            }

            public void InsertOrUpdate(LoggerCacheKey cacheKey, Logger newlogger)
            {
                _loggerCache[cacheKey] = new WeakReference(newlogger);
            }

            public List<Logger> AllCacheValues
            {
                get
                {
                    var targets = new List<Logger>();
                    foreach (var loggerCacheValue in _loggerCache.Values)
                    {
                        var logger = loggerCacheValue.Target as Logger;
                        targets.Add(logger);
                    }
                    return targets;
                }
            }
        }
    }
}
