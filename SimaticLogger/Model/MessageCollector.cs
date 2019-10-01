using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace SimaticLogger
{
    class MessageCollector : BindableBase
    {
        public MessageCollector()
        {            
            Messages = new ReadOnlyObservableCollection<Message>(messages);
            SimaticClient client = new SimaticClient();
            client.NewMessage += Client_NewMessage;            
        }

        private void Client_NewMessage(object sender, MessageArgs e)
        {
            messages.Add(new Message(e.MessageText, ""));            
        }
        private readonly ObservableCollection<Message> messages = new ObservableCollection<Message>();
        public ReadOnlyObservableCollection<Message> Messages { get; }        
        public void Collect()
        {
            messages.Add(new Message("my message4", "02.06"));
        }
    }
}
