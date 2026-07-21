using WaveApp.ViewModels;

namespace WaveApp.Views;

public partial class DashboardView : ContentPage
{
	public DashboardView(DashboardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}