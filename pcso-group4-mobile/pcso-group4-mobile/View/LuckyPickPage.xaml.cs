using Newtonsoft.Json;
using pcso_group4_mobile.ViewModel;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Linq;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using pcso_group4_mobile.Model;


namespace pcso_group4_mobile.View;

public partial class LuckyPickPage : ContentPage
{

    public List<GameModel> games { get; set; }

    public LuckyPickPage(LuckyPickViewModel luckyPickViewModel)
	{
        InitializeComponent();
        BindingContext = luckyPickViewModel;        

        //var gamelist = GameList();
        //foreach (var item in gamelist)
        //{
        //    game_picker.Items.Add(item.Game.ToString());
        //}
    }

    private List<GameModel> GameList()
    {
        return games = new List<GameModel>()
        {
            new GameModel() { ID = 1, Game = 642 },
            new GameModel() { ID = 2, Game = 645 },
            new GameModel() { ID = 3, Game = 649 },
            new GameModel() { ID = 4, Game = 655 },
            new GameModel() { ID = 5, Game = 658 }
        };

    }

}
