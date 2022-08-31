using System;
using System.Collections.Generic;
using System.Text;
using AppRpgEtec.Services.Usuarios;
using AppRpgEtec.Models;
using System.Windows.Input; //using do ICommand
using Xamarin.Forms;
using System.Threading.Tasks;


namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        private Usuario Usuario;

        public ICommand EntrarCommand { get; set; }

        //ctor + TAB + TAB: atalho para criar o construtor
        //         Construtor
        public UsuarioViewModel()
        {
            this.Usuario = new Usuario();
            uService = new UsuarioService();
            RegistrarCommands();
        }
        //método para vincular o método consultarUsuario() para o comando declara no inicio da classe
        public void RegistrarCommands()
        {
            EntrarCommand = new Command(async () => { await ConsultarUsuario(); });
        }


        public async Task ConsultarUsuario()//Método para buscar um usuário
        {
            try
            {
                Usuario u = null;
                u = await uService.PostLoginUsuarioAsync(Usuario);

                if(!string.IsNullOrEmpty(u.Token))
                {
                    //Guardando dados do usuário para uso futuro
                    Application.Current.Properties["UsuarioId"] = u.Id;
                    Application.Current.Properties["UsuarioUsername"] = u.Username;
                    Application.Current.Properties["UsuarioPerfil"] = u.Perfil;
                    Application.Current.Properties["UsuarioToken"] = u.Token;

                    string mensagem = string.Format("Bem-vindo {0}", u.Username);

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new AppRpgEtec.MainPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        #region ViewProperties
        //Propiedades vinculadas ao Binding da View
        public string Login
        {
            get { return this.Usuario.Username; }
            set
            {
                this.Usuario.Username = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return this.Usuario.PasswordString; }
            set
            {
                this.Usuario.PasswordString = value;
                OnPropertyChanged();
            }
        }
        #endregion

    }
}
