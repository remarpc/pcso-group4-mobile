using pcso_group4_mobile.Model;
using pcso_group4_mobile.ViewModel;


namespace pcso_group4_mobile.View;

public partial class LuckyPickPage : ContentPage
{
    public int Number { get; set; } = 0;
    public LuckyPickPage(LuckyPickViewModel luckyPickViewModel)
    {
        InitializeComponent();
        BindingContext = luckyPickViewModel;
    }

    private void game_picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (game_picker.SelectedIndex == 0)
        {
            Number = 42;
        }
        else if (game_picker.SelectedIndex == 1)
        {
            Number = 45;
        }
        else if (game_picker.SelectedIndex == 2)
        {
            Number = 49;
        }
        else if (game_picker.SelectedIndex == 3)
        {
            Number = 55;
        }
        else if (game_picker.SelectedIndex == 4)
        {
            Number = 58;
        }
    }

    private void btnRandomNumber(object sender, EventArgs e)
    {
        if (Number == 0)
            App.Current.MainPage.DisplayAlert("Notice", "No selected game, please select", "Accept");
        else
        {
            var rnd = new Random();
            var randomNumbers = Enumerable.Range(1, Number).OrderBy(x => rnd.Next()).Take(6).ToList();
            lblNum1.Text = randomNumbers.ElementAt(0).ToString();
            lblNum2.Text = randomNumbers.ElementAt(1).ToString();
            lblNum3.Text = randomNumbers.ElementAt(2).ToString();
            lblNum4.Text = randomNumbers.ElementAt(3).ToString();
            lblNum5.Text = randomNumbers.ElementAt(4).ToString();
            lblNum6.Text = randomNumbers.ElementAt(5).ToString();
        }
    }

    private void btnFrequency_Clicked(object sender, EventArgs e)
    {
        LuckyPickViewModel lp = new LuckyPickViewModel();

        if (game_picker.SelectedIndex < 0)
        {
            App.Current.MainPage.DisplayAlert("Notice", "No selected game, please select", "Accept");
        }
        else
        {
            var frequency = new CombinationModel();
            frequency = lp.frequency.Where(x => x.GameId == game_picker.SelectedIndex + 1).FirstOrDefault();
            lblNum1.Text = frequency.Digit1.ToString();
            lblNum2.Text = frequency.Digit2.ToString();
            lblNum3.Text = frequency.Digit3.ToString();
            lblNum4.Text = frequency.Digit4.ToString();
            lblNum5.Text = frequency.Digit5.ToString();
            lblNum6.Text = frequency.Digit6.ToString();
        }
    }
}
