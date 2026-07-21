using Microsoft.Extensions.Logging;
using WaveApp.Data;
using WaveApp.Services;
using WaveApp.ViewModels;
using WaveApp.Views;

namespace WaveApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Banco local
        builder.Services.AddDbContext<AppDbContext>();

        // Supabase
        builder.Services.AddSingleton<SupabaseService>();

        // Serviços
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<AlunoService>();

        // ViewModels
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<DashboardViewModel>();
        builder.Services.AddSingleton<AlunoViewModel>();

        // Páginas
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<DashboardView>();
        builder.Services.AddSingleton<AlunoView>();
        builder.Services.AddSingleton<AppShell>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
