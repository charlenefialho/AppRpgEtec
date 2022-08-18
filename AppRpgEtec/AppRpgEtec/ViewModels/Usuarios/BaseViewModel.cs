using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel; //using 
using System.Runtime.CompilerServices;//using

namespace AppRpgEtec.ViewModels.Usuarios
{
    /*estruturaremos a classe BaseViewModel para centralizar o
    método OnPropertyChanged para as demais classes ViewModel.Essa configuração, como vimos, é a que
reflete as alterações das classes espontaneamente para as Views e vice-versa.*/
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
