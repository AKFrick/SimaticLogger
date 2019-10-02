using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace SimaticLogger
{
    public class MessageArgs : EventArgs
    {
        public MessageArgs(string messageText)
        {
            MessageText = messageText;         
        }
        public string MessageText { get; private set; }
    }
    public class SimaticClient
    {
        public SimaticClient()
        {            
        }
        Thread thread;
        private TcpClient client;
        private NetworkStream networkStream;
        private byte[] data = new byte[256];
        public void Connect()
        {
            if (thread == null)
            {
                client = new TcpClient("192.168.20.2", 2000);
                networkStream = client.GetStream();
                thread = new Thread(() =>
                {
                    while (true)
                    {
                        int bytes = networkStream.Read(data, 0, data.Length);
                        RaiseNewMessage(System.Text.Encoding.ASCII.GetString(data, 2, data[2]));
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
        public event EventHandler<MessageArgs> NewMessage;
        private void RaiseNewMessage(string message)
        {
            NewMessage?.Invoke(this, new MessageArgs(message));
        }
    }

}
