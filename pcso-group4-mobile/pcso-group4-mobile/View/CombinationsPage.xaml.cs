using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;
using pcso_group4_mobile.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace pcso_group4_mobile.View;

public partial class CombinationsPage : ContentPage, INotifyPropertyChanged
{
    ServiceClient sc = new ServiceClient();

    public ObservableCollection<GameModel> games { get; set; }

    int id;
    public int Id
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged(nameof(id));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string i) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i));


    public CombinationsPage(CombinationsViewModel combinationsViewModel)
    {
        InitializeComponent();
        BindingContext = combinationsViewModel;
    }

    private void gamePickerSelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private bool isEntriesComplete()
    {
        bool response = true;
        if (txtNum1.Text == "" || txtNum1.Text == null) response = false;
        if (txtNum2.Text == "" || txtNum2.Text == null) response = false;
        if (txtNum3.Text == "" || txtNum3.Text == null) response = false;
        if (txtNum4.Text == "" || txtNum4.Text == null) response = false;
        if (txtNum5.Text == "" || txtNum5.Text == null) response = false;
        if (txtNum6.Text == "" || txtNum6.Text == null) response = false;

        return response;
    }

    private bool isEntriesNumber()
    {
        try
        {
            Convert.ToInt16(txtNum1.Text);
            Convert.ToInt16(txtNum2.Text);
            Convert.ToInt16(txtNum3.Text);
            Convert.ToInt16(txtNum4.Text);
            Convert.ToInt16(txtNum5.Text);
            Convert.ToInt16(txtNum6.Text);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    private string getGameName(Picker p)
    {
        string result = "";
        if (p.SelectedIndex == 0) result = "6/42";
        else if (p.SelectedIndex == 1) result = "6/45";
        else if (p.SelectedIndex == 2) result = "6/49";
        else if (p.SelectedIndex == 3) result = "6/55";
        else if (p.SelectedIndex == 4) result = "6/58";
        return result;
    }

    private void btnAddCombination(object sender, EventArgs e)
    {
        if (cp_game_picker.SelectedIndex < 0)
            App.Current.MainPage.DisplayAlert("Warning", "No selected game, please select", "Ok");
        else if (isEntriesComplete() == false)
            App.Current.MainPage.DisplayAlert("Warning", "Please enter six numbers", "Ok");
        else if (isEntriesNumber() == false)
            App.Current.MainPage.DisplayAlert("Warning", "Accept number value only", "Ok");
        else
        {
            CombinationModel combination = new CombinationModel();

            CombinationModel c = new CombinationModel()
            {
                GameId = cp_game_picker.SelectedIndex + 1,
                Digit1 = Convert.ToInt16(txtNum1.Text),
                Digit2 = Convert.ToInt16(txtNum2.Text),
                Digit3 = Convert.ToInt16(txtNum3.Text),
                Digit4 = Convert.ToInt16(txtNum4.Text),
                Digit5 = Convert.ToInt16(txtNum5.Text),
                Digit6 = Convert.ToInt16(txtNum6.Text)
            };
            sc.PostCombination(c);
            App.Current.MainPage.DisplayAlert("Info", $"Numbers combination for {getGameName(cp_game_picker)} Game saved.", "Ok");

            txtNum1.Text = String.Empty;
            txtNum2.Text = String.Empty;
            txtNum3.Text = String.Empty;
            txtNum4.Text = String.Empty;
            txtNum5.Text = String.Empty;
            txtNum6.Text = String.Empty;
            OnPropertyChanged(nameof(txtNum1.Text));
            OnPropertyChanged(nameof(txtNum2.Text));
            OnPropertyChanged(nameof(txtNum3.Text));
            OnPropertyChanged(nameof(txtNum4.Text));
            OnPropertyChanged(nameof(txtNum5.Text));
            OnPropertyChanged(nameof(txtNum6.Text));

        }
    }
}