using pcso_group4_mobile.ViewModel;
namespace pcso_group4_mobile.View;

public partial class LuckyPickPage : ContentPage
{
    GamesViewModel viewModel;

    public LuckyPickPage(LuckyPickViewModel luckyPickViewModel)
	{
		InitializeComponent();
		BindingContext = luckyPickViewModel;
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var _picker = sender as Picker;
        var collection = viewModel.gamesList;
        var index = _picker.SelectedIndex;
        //if (!picker_2.IsEnabled)
        //{
        //    picker_2.IsEnabled = true;
        //    picker_2.Title = "Select the PizzaIngredien";
        //}
        //picker_2.ItemsSource = new ObservableCollection<PizzaIngrediens>(collection[index].PizzaIngredientsList);
    }
}