using pcso_group4_mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcso_group4_mobile.Contracts;

public interface IGame
{
    Task<bool> AddGameAsync(GameModel gameModel);
    Task<bool> DeleteGameAsync(int id);
    Task<GameModel> GetGameAsync(int id);
    Task<List<GameModel>> GetGamesAsync();    
}
