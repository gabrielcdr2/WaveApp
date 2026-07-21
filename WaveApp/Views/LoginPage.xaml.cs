namespace WaveApp.Views;
using WaveApp.ViewModels;
public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}