namespace WaveApp;

/// <summary>
/// Classe de controle do Shell de navegação do aplicativo.
/// </summary>
public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("AlunoPage", typeof(Views.AlunoView));
        Routing.RegisterRoute("DashboardPage", typeof(Views.DashboardView));
    }
}