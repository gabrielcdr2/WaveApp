using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WaveApp.Data;
using WaveApp.Services;
using WaveApp.Views;

namespace WaveApp.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly AuthService _authService;
    private readonly AppShell _appShell;

    [ObservableProperty] private string _login = string.Empty;
    [ObservableProperty] private string _senha = string.Empty;
    [ObservableProperty] private string _erroMessage = string.Empty;
    [ObservableProperty] private bool _temErro;
    [ObservableProperty] private bool _carregando;

    public LoginViewModel(AuthService authService, AppShell appShell)
    {
        _authService = authService;
        _appShell = appShell;
    }

    [RelayCommand]
    private async Task Entrar()
    {
        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Senha))
        {
            ErroMessage = "Preencha todos os campos.";
            TemErro = true;
            return;
        }

        Carregando = true;
        TemErro = false;

        try
        {
            var sucesso = _authService.Login(Login, Senha);

            if (sucesso)
            {
                Application.Current!.Windows[0].Page = _appShell;
            }
            else
            {
                ErroMessage = "Usuário ou senha incorretos.";
                TemErro = true;
            }
        }
        finally
        {
            Carregando = false;
        }
    }
}