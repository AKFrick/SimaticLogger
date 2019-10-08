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
        private MessageCollector messageCollector = new MessageCollector();
        public ObservableCollection<Message> Messages { get; }
        public DelegateCommand ConnectPlc { get; }
        public DelegateCommand DisconnectPlc { get; }
    }
}
