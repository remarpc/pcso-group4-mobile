using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcso_group4_mobile.ViewModel
{
    public class GamesViewModel
    {
        public GamesViewModel()
        {
            gamesList = new ObservableCollection<Games>();
        }

        public ObservableCollection<Games> gamesList { get; set; }
    }

    public class Games
    {
        public int ID { get; set; }
        public int Game { get; set; }
    }

}
