using pcso_group4_mobile.ViewModel;

namespace pcso_group4_mobile.View;

public partial class CombinationsPage : ContentPage
{
	public CombinationsPage(CombinationsViewModel combinationsViewModel)
	{
		InitializeComponent();
		BindingContext = combinationsViewModel;
	}
}