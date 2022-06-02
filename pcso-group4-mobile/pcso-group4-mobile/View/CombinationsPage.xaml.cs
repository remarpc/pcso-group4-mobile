using pcso_group4_mobile.ViewModel;

namespace pcso_group4_mobile.View;

public partial class CombinationsPage : ContentPage
{
	private int GameType { get; set; } = 0;

	public CombinationsPage(CombinationsViewModel combinationsViewModel)
	{
		InitializeComponent();
		BindingContext = combinationsViewModel;
	}

	private void gamePickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }



}