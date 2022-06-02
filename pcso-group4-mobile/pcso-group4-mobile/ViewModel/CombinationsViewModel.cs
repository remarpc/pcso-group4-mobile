using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace pcso_group4_mobile.ViewModel
{
    public partial class CombinationsViewModel : BaseViewModel
    {
        ServiceClient sc = new ServiceClient();

        public ObservableCollection<GameModel> games { get; set; }

        public CombinationsViewModel()
        {
            //get gametype
            games = sc.GetGamesAsync();
        }
    }
}
