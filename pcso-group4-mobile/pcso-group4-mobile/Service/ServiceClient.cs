using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using pcso_group4_mobile.Model;

namespace pcso_group4_mobile.Service;

public class ServiceClient
{
    public const string url = "https://pcso-group4-backend.azurewebsites.net/";
    public static async Task<List<GameModel>> GetGames()
    {
        try
        {
            HttpClient client = new HttpClient();           
            string response = await client.GetStringAsync(url + "/gameitems");
            List<GameModel> games = JsonConvert.DeserializeObject<List<GameModel>>(response);
            return games;
        }
        catch (Exception)
        {
            throw;
        }
    
    }
}
