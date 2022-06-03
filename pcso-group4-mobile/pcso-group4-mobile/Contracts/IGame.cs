using pcso_group4_mobile.Model;

namespace pcso_group4_mobile.Contracts;

public interface IGame
{
    Task<bool> AddGameAsync(GameModel gameModel);
    Task<bool> DeleteGameAsync(int id);
    Task<GameModel> GetGameAsync(int id);
    Task<List<GameModel>> GetGamesAsync();
    Task<List<CombinationModel>> GetFrequencyAsync();
}
