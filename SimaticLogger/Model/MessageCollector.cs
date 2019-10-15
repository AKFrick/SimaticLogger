using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace SimaticLogger
{
    public class MessageCollector : BindableBase
    {
        public MessageCollector()
        {
            Messages = new ReadOnlyObservableCollection<Message>(messages);
            client = new SimaticClient();
            client.NewMessageCame += Client_NewMessageCame;
            client.NewConnStatus += (text) => {
                ConnectStatus = text;
                RaisePropertyChanged(nameof(ConnectStatus));
            };
        }
        private SimaticClient client;
        private readonly ObservableCollection<Message> messages = new ObservableCollection<Message>();
        public ReadOnlyObservableCollection<Message> Messages { get; }
        public string ConnectStatus { get; set; }
        public void StartGathering() => client.Connect();
        public void StopGathering() => client.Disconnect();
        private void Client_NewMessageCame(object sender, MessageArgs e)
        {
            messages.Add(new Message(e.MessageText, ""));
        }        
    }
 }
