using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pcso_group4_mobile.Model;

namespace pcso_group4_mobile.Service;

public class ServiceClient
{
    public const string baseUrl = "https://pcso-group4-backend.azurewebsites.net/";

    public ObservableCollection<GameModel> GetGamesAsync()
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(baseUrl + "gameitems");
                var games = JsonConvert.DeserializeObject<ObservableCollection<GameModel>>(response.Result);
                return games;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

}
