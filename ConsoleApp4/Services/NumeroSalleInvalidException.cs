using System;
using System.Runtime.Serialization;

namespace ConsoleApp4.Services {
    [Serializable]
    public class NumeroSalleInvalidException : Exception {
        public NumeroSalleInvalidException() {
        }

        public NumeroSalleInvalidException(string message) : base(message) {
        }

        public NumeroSalleInvalidException(string message, Exception innerException) : base(message, innerException) {
        }

        protected NumeroSalleInvalidException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}