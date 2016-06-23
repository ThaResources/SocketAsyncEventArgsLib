using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketAsyncEventArgsLib
{
    /// <summary>
    /// Provides data from a send event where a session sends data to the client.
    /// </summary>
    /// <typeparam name="T">The session class.</typeparam>
    public class SocketSentEventArgs<T> : EventArgs where T : SessionBase
    {
        /// <summary>
        /// The session who sends data.
        /// </summary>
        public T Session
        {
            get;
            private set;
        }

        /// <summary>
        /// The data sent to the client.
        /// </summary>
        public byte[] Data
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of bytes sent to the client.
        /// </summary>
        public int BytesSent
        {
            get;
            private set;
        }

        internal SocketSentEventArgs(T session, byte[] data, int bytesSent)
        {
            Session = session;
            Data = data;
            BytesSent = bytesSent;
        }
    }
}
