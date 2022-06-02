using Newtonsoft.Json;
using pcso_group4_mobile.Contracts;
using pcso_group4_mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pcso_group4_mobile.Service;

public class GameService : IGame
{   
    public async Task<bool> AddGameAsync(GameModel gameModel)
    {
        if (gameModel.ID == 0)
        {
            string json = JsonConvert.SerializeObject(gameModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            string url = "https://pcso-group4-backend.azurewebsites.net/gameitems";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PostAsync("", content);

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
        }
        else
        {
            string json = JsonConvert.SerializeObject(gameModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            string url = "https://pcso-group4-backend.azurewebsites.net/gameitems/" + gameModel.ID;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PutAsync("", content);
            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(true);

    }

    public async Task<bool> DeleteGameAsync(int id)
    {
        var client = new HttpClient();
        string url = "https://pcso-group4-backend.azurewebsites.net/gameitems/" + id;
        client.BaseAddress = new Uri(url);
        HttpResponseMessage response = await client.DeleteAsync("");
        if (response.IsSuccessStatusCode)
        {
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }

    public async Task<GameModel> GetGameAsync(int id)
    {
        var gameModel = new GameModel();
        var client = new HttpClient();
        string url = "https://pcso-group4-backend.azurewebsites.net/gameitems/" + id;
        client.BaseAddress = new Uri(url);
        HttpResponseMessage response = await client.GetAsync("");

        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            gameModel = JsonConvert.DeserializeObject<GameModel>(content);
        }
        return await Task.FromResult(gameModel);        
    }

    public async Task<List<GameModel>> GetGamesAsync()
    {
        var gameModelList = new List<GameModel>();
        var client = new HttpClient();
        string url = "https://pcso-group4-backend.azurewebsites.net/gameitems/";
        client.BaseAddress = new Uri(url);
        HttpResponseMessage response = await client.GetAsync("");

        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            gameModelList = JsonConvert.DeserializeObject<List<GameModel>>(content);
        }
        return gameModelList;
    }
}
