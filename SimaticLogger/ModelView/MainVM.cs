using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using System.Linq;
using System.Collections.Specialized;
using Prism.Commands;

namespace SimaticLogger
{
    public class MainVM : BindableBase
    {
        public MainVM()
        {
            Messages = new ObservableCollection<Message>(messageCollector.Messages);
            ((INotifyCollectionChanged)messageCollector.Messages).CollectionChanged += (s, a) =>
               {
                   if (a.NewItems?.Count != 0) Messages.Add(a.NewItems[0] as Message);
                   if (a.OldItems?.Count == 1) Messages.Remove(a.OldItems[0] as Message);
               };
            InsertNew = new DelegateCommand(() =>
                {
                    messageCollector.Collect();
                    BtnContent = "Btn 2";
                    RaisePropertyChanged(nameof(BtnContent));
                });
            DeleteTop = new DelegateCommand(() => Messages.Remove(Messages.First()));                                        
        }
        private MessageCollector messageCollector = new MessageCollector();
        public ObservableCollection<Message> Messages { get; }
        public DelegateCommand InsertNew { get; }
        public DelegateCommand DeleteTop { get; }
        public string BtnContent { get; set; } = "Btn 1";
    }
}
