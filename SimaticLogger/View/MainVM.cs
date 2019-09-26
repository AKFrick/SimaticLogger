using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace SimaticLogger
{
    public class MainVM : BindableBase
    {
        public List<Message> Messages { get; set; }
        public MainVM()
        {            
        }       
    }
}
