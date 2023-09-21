using AppRpgEtec.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Login.Models;

namespace Login.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }

        public UsuarioViewModel() 
        { 
            uService = new UsuarioService();
            InicializarCommands();
        }
        public async void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
        }

        public async Task AutenticarUsuario()//Método para autenticar um usuário
        {
            try
            {
                Usuario u = new Usuario();
                u.Nome = Login;
                u.Senha = senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Senha))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Nome}.";

                    //Guardando dados do usuário para uso futuro
                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioUserName", uAutenticado.Nome);
                    Preferences.Set("UsuarioEmail", uAutenticado.Email);
                    Preferences.Set("UsuarioSenha", uAutenticado.Senha);

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");
                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos : (", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        #region AtributosPropriedades
        private string login = string.Empty;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        private string senha = string.Empty;
        public string Senha
        {
            get { return Senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Métodos
        public async Task RegistrarUsuario()//Método para registrar um usuário
        {
            try
            {
                Usuario u = new Usuario();
                u.Nome = Login;
                u.Senha = senha;

                Usuario uRegistrado = await uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.Id != 0)
                {
                    string mensagem = $"Usuario Id {uRegistrado.Id} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();//Remove a página da pilha de visualização
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        #endregion
    }
}
