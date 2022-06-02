using Newtonsoft.Json;
using pcso_group4_mobile.Contracts;
using pcso_group4_mobile.Model;
using System.Text;

namespace pcso_group4_mobile.Service
{
    partial class CombinationService : ICombination
    {
        private string url = "https://pcso-group4-backend.azurewebsites.net/";

        public CombinationService()
        {
            InitializeComponent();
        }

        public async Task<bool> AddNumberCombinationAsync(CombinationModel combinationModel)
        {
            HttpClient client = new HttpClient();
            string json = JsonConvert.SerializeObject(combinationModel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri($"{url}combinationitems");
            HttpResponseMessage response = await client.PostAsync("", content);
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public async Task<bool> DeleteNumberCombinationAsync(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{url}combinationitems/{id}");
            HttpResponseMessage response = await client.DeleteAsync("");
            return await Task.FromResult(response.IsSuccessStatusCode);
        }

        public Task<CombinationModel> GetNumberCombinationAsync(int id)
        {
            CombinationModel cm = new CombinationModel();
            return Task.FromResult(cm);
        }

        public async Task<List<CombinationModel>> GetNumberCombinationsAsync()
        {
            HttpClient client = new HttpClient();
            List<CombinationModel> combinations = new List<CombinationModel>();
            client.BaseAddress = new Uri($"{url}combinationitems");
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                combinations = JsonConvert.DeserializeObject<List<CombinationModel>>(content);
            }
            return combinations;
        }
    }
}
