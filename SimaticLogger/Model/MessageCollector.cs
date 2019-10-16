using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace SimaticLogger
{
    /// <summary>
    /// Collect messages in <see cref="Messages"/>
    /// </summary>
    public class MessageCollector : BindableBase
    {
        public MessageCollector()
        {
            Messages = new ReadOnlyObservableCollection<Message>(messages);
            client = new SimaticClient();
            client.NewMessage += (msg) => messages.Add(msg);
            client.NewConnStatus += (text) => {
                ConnectStatus = text;
                RaisePropertyChanged();
            };
        }
        private SimaticClient client;
        private readonly ObservableCollection<Message> messages = new ObservableCollection<Message>();
        /// <summary>
        /// Messages, collected from PLC
        /// </summary>
        public ReadOnlyObservableCollection<Message> Messages { get; }
        /// <summary>
        /// status of connection to PLC
        /// </summary>
        public string ConnectStatus { get; set; }
        /// <summary>
        /// connect to PLC and begin collecting messages in <see cref="Messages"/>
        /// </summary>
        public void StartGathering() => client.Connect();
        /// <summary>
        /// disconnect from PLC
        /// </summary>
        public void StopGathering() => client.Disconnect();       
    }
 }
