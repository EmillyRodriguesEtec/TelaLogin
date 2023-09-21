using Login.ViewModels.Usuarios;

namespace Login.Views.Usuarios;

public partial class LoginView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public LoginView()
	{
		InitializeComponent();

		usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;
	}
}