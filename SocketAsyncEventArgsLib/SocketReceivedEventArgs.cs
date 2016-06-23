using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAsyncEventArgsLib
{
    /// <summary>
    /// Provides data from a receive event where a session receives data from the client.
    /// </summary>
    /// <typeparam name="T">The session class.</typeparam>
    public class SocketReceivedEventArgs<T> : EventArgs where T : SessionBase
    {
        /// <summary>
        /// The session who received data.
        /// </summary>
        public T Session
        {
            get;
            private set;
        }

        /// <summary>
        /// The data received from the client.
        /// </summary>
        public byte[] Data
        {
            get;
            private set;
        }

        /// <summary>
        /// The amount of bytes received from the client.
        /// </summary>
        public int BytesReceived
        {
            get;
            private set;
        }

        internal SocketReceivedEventArgs(ref T session, byte[] data, int bytesReceived)
        {
            Session = session;
            Data = data;
            BytesReceived = bytesReceived;
        }
    }
}
