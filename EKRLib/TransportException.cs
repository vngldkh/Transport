using System;

namespace EKRLib
{
    /// <summary>
    /// Класс исключения транспорта.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        public TransportException() : base() { }
        public TransportException(string message) : base(message) { }
        public TransportException(string message, Exception inner) : base(message, inner) { }
        
        protected TransportException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}