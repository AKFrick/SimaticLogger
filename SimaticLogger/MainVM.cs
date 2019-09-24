using System.ComponentModel;

namespace SimaticLogger
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string btnContext = "THIS IS MY BTN!";
        public string BtnContext { get { return btnContext; } set { btnContext = value; } }
    }
}
