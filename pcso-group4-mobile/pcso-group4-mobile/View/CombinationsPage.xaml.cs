using pcso_group4_mobile.Contracts;
using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;
using pcso_group4_mobile.ViewModel;
using System.ComponentModel;
using System.Text;

namespace pcso_group4_mobile.View;

public partial class CombinationsPage : ContentPage, INotifyPropertyChanged
{
    CombinationsViewModel cvm = new CombinationsViewModel();
    ICombination ic = new CombinationService();

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
        Picker picker = sender as Picker;
        int id = picker.SelectedIndex;

        List<CombinationModel> combinations = (List<CombinationModel>)cvm.combinations.Where(i => i.GameId == (id + 1)).ToList();

        if (id >= 0)
        {
            DisplayCombinations(combinations);
        }
    }

    private void DisplayCombinations(List<CombinationModel> items)
    {
        foreach (CombinationModel c in items)
        {
            c.result = $"{c.Digit1.ToString("0#")} - {c.Digit2.ToString("0#")} - {c.Digit3.ToString("0#")} - {c.Digit4.ToString("0#")} - {c.Digit5.ToString("0#")} - {c.Digit6.ToString("0#")}";
        }
        cv_combinations.ItemsSource = items;
        OnPropertyChanged(nameof(cv_combinations.ItemsSource));
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

    private bool areNumbersOutOfRange(int maxnum)
    {
        bool result = false;

        int n1 = Convert.ToInt16(txtNum1.Text);
        int n2 = Convert.ToInt16(txtNum2.Text);
        int n3 = Convert.ToInt16(txtNum3.Text);
        int n4 = Convert.ToInt16(txtNum4.Text);
        int n5 = Convert.ToInt16(txtNum5.Text);
        int n6 = Convert.ToInt16(txtNum6.Text);

        if (n1 < 1 || n1 > maxnum) result = true;
        if (n2 < 1 || n2 > maxnum) result = true;
        if (n3 < 1 || n3 > maxnum) result = true;
        if (n4 < 1 || n4 > maxnum) result = true;
        if (n5 < 1 || n5 > maxnum) result = true;
        if (n6 < 1 || n6 > maxnum) result = true;

        return result;
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
        int maxnum = Convert.ToInt16(getGameName(cp_game_picker).Substring(2));
        if (cp_game_picker.SelectedIndex < 0)
            App.Current.MainPage.DisplayAlert("Validation Error", "No selected game, please select.", "Ok");
        else if (isEntriesComplete() == false)
            App.Current.MainPage.DisplayAlert("Validation Error", "Please enter six numbers.", "Ok");
        else if (isEntriesNumber() == false)
            App.Current.MainPage.DisplayAlert("Validation Error", "Accept number value only.", "Ok");
        else if (areNumbersOutOfRange(maxnum) == true)
            App.Current.MainPage.DisplayAlert("Validation Error", $"Numbers should be from 0 to {maxnum} only.", "Ok");
        else
        {
            int gID = cp_game_picker.SelectedIndex + 1;
            CombinationModel combination = new CombinationModel();

            CombinationModel c = new CombinationModel()
            {
                GameId = gID,
                Digit1 = Convert.ToInt16(txtNum1.Text),
                Digit2 = Convert.ToInt16(txtNum2.Text),
                Digit3 = Convert.ToInt16(txtNum3.Text),
                Digit4 = Convert.ToInt16(txtNum4.Text),
                Digit5 = Convert.ToInt16(txtNum5.Text),
                Digit6 = Convert.ToInt16(txtNum6.Text)
            };

            ic.AddNumberCombinationAsync(c);
            App.Current.MainPage.DisplayAlert("Info", $"Numbers combination for {getGameName(cp_game_picker)} Game saved.", "Ok");
            List<CombinationModel> list = Task.Run(() => ic.GetNumberCombinationsAsync()).Result; 
            List<CombinationModel> combinations = (List<CombinationModel>) list.Where(i => i.GameId == (gID)).ToList();
            DisplayCombinations(combinations);

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

    private void SwipeDeleteItem_Clicked(object sender, EventArgs e)
    {
        var action = (SwipeItem)sender;
        var delcombination = (CombinationModel)action.BindingContext;
        ic.DeleteNumberCombinationAsync(delcombination.Id);
        App.Current.MainPage.DisplayAlert("Item Deleted", $"Numbers combination has been deleted.", "Ok");

        List<CombinationModel> list = Task.Run(() => ic.GetNumberCombinationsAsync()).Result;
        List<CombinationModel> combinations = (List<CombinationModel>)list.Where(i => i.GameId == (delcombination.GameId)).ToList();
        DisplayCombinations(combinations);
    }
}