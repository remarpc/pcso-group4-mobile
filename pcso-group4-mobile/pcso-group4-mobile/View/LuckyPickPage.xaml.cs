using pcso_group4_mobile.ViewModel;
using System.Collections.ObjectModel;

namespace pcso_group4_mobile.View;

public partial class LuckyPickPage : ContentPage
{
    GamesViewModel viewModel;
    public List<Games> games = new List<Games>();

    public LuckyPickPage(LuckyPickViewModel luckyPickViewModel)
	{
        InitializeComponent();
        
        games = new List<Games>()
        {
            new Games() { ID = 1, Game = 642 },
            new Games() { ID = 2, Game = 645 },
            new Games() { ID = 3, Game = 649 },
            new Games() { ID = 4, Game = 655 },
            new Games() { ID = 5, Game = 658 }
        };


        //picker_1.SetBinding(Picker.ItemsSourceProperty, "games");
        //picker_1.ItemDisplayBinding = new Binding("Game");
        //picker_1.ItemsSource = games;
        

        BindingContext = luckyPickViewModel;
        //picker_1.ItemDisplayBinding = new Binding("Game");
        //picker_1.BindingContext = games;


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