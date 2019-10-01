using System;
using System.Net;
using System.Net.Sockets;
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
        public event EventHandler<MessageArgs> NewMessage;
        private void RaiseNewMessage()
        {
            NewMessage?.Invoke(this, new MessageArgs("new message"));
        }
    }
    
}
