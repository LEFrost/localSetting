using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace localSetting
{
    internal class items:INotifyPropertyChanged
    {
        private string st;

        public string St
        {
            get
            {
                return st;
            }

            set
            {
                st = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}