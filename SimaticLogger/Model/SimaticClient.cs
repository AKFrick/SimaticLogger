using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace SimaticLogger
{
    /// <summary>
    /// Provides connection to PLC to get messages repeatly from Queue, stored in PLC
    /// </summary>
    public class SimaticClient
    {
        /// <summary>
        /// occurs when one new message received from PLC
        /// </summary>
        public event EventHandler<MessageArgs> NewMessageCame;
        /// <summary>
        /// occurs when status of the connection to PLC changed
        /// </summary>
        public event Action<string> NewConnStatus;
        Thread thread;
        private TcpClient client;
        private NetworkStream networkStream;
        private byte[] data = new byte[256];
        /// <summary>
        /// connect to PLC and begin getting message
        /// </summary>
        public void Connect()
        {
            if (thread == null)
            {
                NewConnStatus("Connecting...");
                thread = new Thread(() =>
                   {
                       try
                       {
                           client = new TcpClient("192.168.20.2", 2000);
                           networkStream = client.GetStream();
                           while (true)
                           {
                               int bytes = networkStream.Read(data, 0, data.Length);
                               NewMessageCame(this, new MessageArgs(Encoding.ASCII.GetString(data, 2, data[2])));
                               Thread.Sleep(1000);
                           }
                       }
                       catch (SocketException e) { NewConnStatus(e.Message); }
                   }
                );
                thread.Start();
            }
        }
        /// <summary>
        /// disconnect from PLC and finish getting messages
        /// </summary>
        public void Disconnect()
        {
            if (thread.IsAlive)
            {
                thread.Abort();
                networkStream.Close();
                client.Close();
                thread = null;
            }
        }
    }
}
