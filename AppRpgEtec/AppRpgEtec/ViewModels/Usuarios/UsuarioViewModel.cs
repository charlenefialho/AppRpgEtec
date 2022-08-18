using System;
using System.Collections.Generic;
using System.Text;
using AppRpgEtec.Services.Usuarios;
using AppRpgEtec.Models;
using System.Windows.Input; //using do ICommand

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        private Usuario Usuario;

        public ICommand EntarCommand { get; set; }

    }
}
