using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pcso_group4_mobile.Model;
using pcso_group4_mobile.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using pcso_group4_mobile.Contracts;
using System.Net.Http;

namespace pcso_group4_mobile.ViewModel;

public partial class LuckyPickViewModel : BaseViewModel
{  

    IGame game = new GameService(); 
    public List<GameModel> games { get { return Task.Run(() => game.GetGamesAsync()).Result; } }

    public LuckyPickViewModel()
    {
        
    }   
}

