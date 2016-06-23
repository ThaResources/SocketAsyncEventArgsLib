using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketAsyncEventArgsLib
{
    /// <summary>
    /// The base class for the session class, holding the default data.
    /// </summary>
    public class SessionBase
    {
        /// <summary>
        /// The underlying <see cref="Socket"/> class of the session.
        /// </summary>
        public Socket Socket
        {
            get;
            set;
        }

        internal SocketAsyncEventArgs ReceiveEventArgs
        {
            get;
            set;
        }

        internal int SendBytesRemainingCount
        {
            get;
            set;
        }

        internal int BytesSentAlreadyCount
        {
            get;
            set;
        }

        internal byte[] DataToSend
        {
            get;
            set;
        }

        public string IP
        {
            get
            {
                return Socket.RemoteEndPoint.ToString().Split(':')[0];
            }
        }

        /// <summary>
        /// Function to be called when the connection is closed. Can be overridden.
        /// </summary>
        public virtual void OnConnectionClose()
        {

        }
    }
}
