using Microsoft.Extensions.DependencyInjection;
using WaveApp.Data;
using WaveApp.Services;
using WaveApp.Views;

namespace WaveApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            var auth = new AuthService(db);
            if (!db.Users.Any(u => u.Login == "admin"))
            {
                auth.CriarUsuario("admin", "admin123");
            }

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var loginPage = Handler?.MauiContext?.Services.GetService<LoginPage>();
            return new Window(new NavigationPage(loginPage));
        }
    }
}