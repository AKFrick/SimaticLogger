using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class Message
    {
        public string Text { get; set; }
        public string Date { get; set; }
        public Message(string text, string date)
        {
            Text = text;
            Date = date;
        }
    }
}
