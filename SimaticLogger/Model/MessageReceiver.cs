using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace SimaticLogger.Model
{
    class MessageCollector : BindableBase
    {
        public MessageCollector()
        {
            Messages = new ReadOnlyObservableCollection<Message>(_messages);
        }
        private readonly ObservableCollection<Message> _messages = new ObservableCollection<Message>();
        public ReadOnlyObservableCollection<Message> Messages;
        public void Collect(Message message)
        {

        }


    }
}
