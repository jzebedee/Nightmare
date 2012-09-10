using System;

namespace Utils.Memory
{
    [Serializable]
    public class MemoryOperationFailedException : Exception
    {
        public MemoryOperationFailedException() { }
        public MemoryOperationFailedException(string message) : base(message) { }
        public MemoryOperationFailedException(string message, Exception inner) : base(message, inner) { }
        protected MemoryOperationFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
