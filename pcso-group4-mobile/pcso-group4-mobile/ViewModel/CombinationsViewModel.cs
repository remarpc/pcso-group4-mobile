using pcso_group4_mobile.Contracts;
using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;

namespace pcso_group4_mobile.ViewModel
{
    public partial class CombinationsViewModel : BaseViewModel
    {
        ICombination ic = new CombinationService();
        public List<CombinationModel> combinations { get { return Task.Run(() => ic.GetNumberCombinationsAsync()).Result; } }

        public List<CombinationModel> cItems = new List<CombinationModel>();

        IGame game = new GameService();
        public List<GameModel> games { get { return Task.Run(() => game.GetGamesAsync()).Result; } }

        public CombinationsViewModel()
        {
        }
    }
}
