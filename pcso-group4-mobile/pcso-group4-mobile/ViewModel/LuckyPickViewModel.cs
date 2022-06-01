using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pcso_group4_mobile.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace pcso_group4_mobile.ViewModel;

public partial class LuckyPickViewModel : BaseViewModel, INotifyPropertyChanged
{
    public ObservableCollection<Games> games { get; set; }

    public LuckyPickViewModel()
    {
        
    }

    public async Task<List<Games>> GetList()
    {
        HttpClient client = new HttpClient();
        string Baseurl = "https://pcso-group4-backend.azurewebsites.net/gameitems";
        string result = await client.GetStringAsync(Baseurl);
        List<Games> games = JsonConvert.DeserializeObject<List<Games>>(result);
        return games;
    }
}

