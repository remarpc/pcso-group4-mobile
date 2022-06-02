using pcso_group4_mobile.Model;

namespace pcso_group4_mobile.Contracts
{
    public interface ICombination
    {
        //this an example
        Task<bool> AddNumberCombinationAsync(CombinationModel combinationModel);

        Task<bool> DeleteNumberCombinationAsync(int id);

        Task<CombinationModel> GetNumberCombinationAsync(int id);

        Task<List<CombinationModel>> GetNumberCombinationsAsync();
    }
}
