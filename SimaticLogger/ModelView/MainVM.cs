using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using System.Linq;
using System.Collections.Specialized;
using Prism.Commands;
using System.Windows;
using System;

namespace SimaticLogger
{
    public class MainVM : BindableBase
    {
        public MainVM()
        {
            messageCollector = new MessageCollector();
            statusBarVM = new StatusBarVM(messageCollector);

            Messages = new ObservableCollection<Message>(messageCollector.Messages);
            ((INotifyCollectionChanged)messageCollector.Messages).CollectionChanged += (s, a) =>
               {
                   if (a.NewItems?.Count != 0)
                        Application.Current.Dispatcher.BeginInvoke(new Action(() => 
                            Messages.Add(a.NewItems[0] as Message)));                
                   if (a.OldItems?.Count == 1)
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                            Messages.Remove(a.OldItems[0] as Message)));
               };

            ConnectPlc = new DelegateCommand(() => messageCollector.StartGathering());
            DisconnectPlc = new DelegateCommand(() => messageCollector.StopGathering());                                        
        }
        private MessageCollector messageCollector;
        public StatusBarVM statusBarVM { get; }
        public ObservableCollection<Message> Messages { get; }
        public DelegateCommand ConnectPlc { get; }
        public DelegateCommand DisconnectPlc { get; }
    }
    public class StatusBarVM: BindableBase
    {
        public StatusBarVM(MessageCollector messageCollector)
        {
            collector = messageCollector;
            collector.PropertyChanged += (s, a) => RaisePropertyChanged(nameof(ConnMsg));            
        }
        private MessageCollector collector;
        public string ConnMsg => collector.ConnectStatus;
    }
}
