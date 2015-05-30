namespace SimpleBackup.Main.Core
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MessageBoxException : Exception
    {
        public MessageBoxException()
        {
        }

        public MessageBoxException(string message) : base(message)
        {
        }

        public MessageBoxException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MessageBoxException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}