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



namespace pcso_group4_mobile.ViewModel;

public partial class LuckyPickViewModel : BaseViewModel
{
    ServiceClient sc = new ServiceClient();
    public ObservableCollection<GameModel> games { get; set; }

    public LuckyPickViewModel()
    {
        games = sc.GetGamesAsync();
    }

    private void GenerateLuckyPickNumbers(int num)
    {
        var rnd = new Random();
        var randomNumbers = Enumerable.Range(1, num).OrderBy(x => rnd.Next()).Take(6).ToList();
    }

   
    
}

