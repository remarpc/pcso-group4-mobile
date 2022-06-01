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
    public const string url = "https://pcso-group4-backend.azurewebsites.net/gameitems";

    public List<GameModel> GetGamesAsync()
    {
        try
        {            
            var client = new HttpClient();
            var response = client.GetStringAsync(url);
            var games = JsonConvert.DeserializeObject<List<GameModel>>(response.Result);
            return games; 
            
        }
        catch (Exception)
        {
            throw;
        }

    }
}
