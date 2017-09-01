using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProfilesDemo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void RaiseAllPropertiesChanged()
        {
            PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }

        protected void RaiseAndUpdate<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            Raise(propertyName);
        }

        protected void Raise(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

