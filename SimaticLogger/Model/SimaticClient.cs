using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace SimaticLogger
{
    public class SimaticClient
    {
        public event EventHandler<MessageArgs> NewMessageCame;        
        public event Action<string> NewConnStatus;
        Thread thread;
        private TcpClient client;
        private NetworkStream networkStream;
        private byte[] data = new byte[256];
        public void Connect()
        {
            NewConnStatus("Connecting...");
            return;
            if (thread == null)
            {
                client = new TcpClient("192.168.20.2", 2000);
                networkStream = client.GetStream();
                thread = new Thread(() =>
                {
                    while (true)
                    {
                        int bytes = networkStream.Read(data, 0, data.Length);
                        NewMessageCame(this, new MessageArgs(Encoding.ASCII.GetString(data, 2, data[2])));
                        Thread.Sleep(1000);
                    }
                });
                thread.Start();
            }
        }
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
