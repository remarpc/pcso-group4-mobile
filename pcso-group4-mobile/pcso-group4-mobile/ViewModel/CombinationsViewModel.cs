using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pcso_group4_mobile.ViewModel
{
    public partial class CombinationsViewModel : BaseViewModel , INotifyPropertyChanged
    {
        ServiceClient sc = new ServiceClient();

        public ObservableCollection<GameModel> games { get; set; }

        public CombinationsViewModel()
        {
            //get gametype
            games = sc.GetGamesAsync();


            PostCombination = new Command(AddCombination);
            var c = new Combination()
            {
                GameID = GameId,
                Number1 = Convert.ToInt16(Num1),
                Number2 = Convert.ToInt16(Num2),
                Number3 = Convert.ToInt16(Num3),
                Number4 = Convert.ToInt16(Num4),
                Number5 = Convert.ToInt16(Num5),
                Number6 = Convert.ToInt16(Num6)
            };

        }

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
        public int GameId { get; set; }
        public string Num1 { get; set; }
        public string Num2 { get; set; }
        public string Num3 { get; set; }
        public string Num4 { get; set; }
        public string Num5 { get; set; }
        public string Num6 { get; set; }

        public ICommand PostCombination { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string i) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(i));

        private void AddCombination()
        {
            Combination combination = new Combination();
            Combination c = new Combination() {
                GameID = GameId,
                Number1 = Convert.ToInt16(Num1),
                Number2 = Convert.ToInt16(Num2), 
                Number3 = Convert.ToInt16(Num3), 
                Number4 = Convert.ToInt16(Num4), 
                Number5 = Convert.ToInt16(Num5), 
                Number6 = Convert.ToInt16(Num6)
            };

            // Clear
            Num1 = ""; Num2 = ""; Num3 = ""; Num4 = ""; Num5 = ""; Num6 = "";
            OnPropertyChanged(nameof(Num1));
            OnPropertyChanged(nameof(Num2));
            OnPropertyChanged(nameof(Num3));
            OnPropertyChanged(nameof(Num4));
            OnPropertyChanged(nameof(Num5));
            OnPropertyChanged(nameof(Num6));
        }
    }
}
