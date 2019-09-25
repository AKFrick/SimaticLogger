using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimaticLogger
{
    public class MainVM : INotifyPropertyChanged
    {
        public List<Message> Messages { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainVM()
        {            
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }         
    }
}
