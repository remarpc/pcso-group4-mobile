using pcso_group4_mobile.Contracts;
using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;

namespace pcso_group4_mobile.ViewModel;

public partial class LuckyPickViewModel : BaseViewModel
{

    IGame game = new GameService();
    public List<GameModel> games { get { return Task.Run(() => game.GetGamesAsync()).Result; } }
    public List<CombinationModel> frequency { get { return Task.Run(() => game.GetFrequencyAsync()).Result; } }

    public LuckyPickViewModel()
    {

    }




}

