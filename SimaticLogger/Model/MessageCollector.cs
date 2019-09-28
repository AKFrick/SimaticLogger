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
            
            messages.Add(new Message("my message2", "02.04"));
            messages.Add(new Message("my message3", "02.05"));
            Messages = new ReadOnlyObservableCollection<Message>(messages);
        }
        private readonly ObservableCollection<Message> messages = new ObservableCollection<Message>();
        public ReadOnlyObservableCollection<Message> Messages { get; }
        public void Collect()
        {
            messages.Add(new Message("my message4", "02.06"));
        }
        public void RemoveTop()
        {
            messages.Remove(messages.First());
        }


    }
}
