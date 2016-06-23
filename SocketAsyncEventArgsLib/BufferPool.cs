using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketAsyncEventArgsLib
{
    internal class BufferPool
    {
        public const int BUF_SIZE = 512;

        public byte[] Buffer
        {
            get;
            private set;
        }

        public int OffsetPointer
        {
            get;
            private set;
        }

        public BufferPool(int SupportedAmount)
        {
            this.Buffer = new byte[BUF_SIZE * 2 * SupportedAmount];
            this.OffsetPointer = default(int);
        }

        public void PushAllReceivers<T>(SocketSystem<T> SocketSystem, ICollection<SocketAsyncEventArgs> Receivers) where T : SessionBase
        {
            foreach (SocketAsyncEventArgs Args in Receivers)
            {
                Args.SetBuffer(Buffer, OffsetPointer, BUF_SIZE);
                Args.Completed += SocketSystem.IO_Completed;

                OffsetPointer += BUF_SIZE;
            }
        }

        public void PushAllSenders<T>(SocketSystem<T> SocketSystem, ICollection<SocketAsyncEventArgs> Senders) where T : SessionBase
        {
            foreach (SocketAsyncEventArgs Args in Senders)
            {
                Args.SetBuffer(Buffer, OffsetPointer, BUF_SIZE);
                Args.Completed += SocketSystem.IO_Completed;

                OffsetPointer += BUF_SIZE;
            }
        }
    }
}
