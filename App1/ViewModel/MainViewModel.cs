using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string textBox { get; set; } = string.Empty;
        public string TextBox
        {
            get => textBox;
            set
            {
                textBox = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
