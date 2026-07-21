using WaveApp.ViewModels;

namespace WaveApp.Views;

public partial class AlunoView : ContentPage
{
    public AlunoView(AlunoViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}