using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface IFarmsService
    {
        Task<List<Farms>> GetFarms();
        Task<Farms> GetFarmId(int id);
        Task<Farms> AddFarm(string FarmName);
        Task<Farms> UpdateFarm(int FarmId, string? FarmName = null);
        Task<Farms> DeleteFarm(int id);
    }
    public class FarmsService : IFarmsService
    {
        private readonly IFarmsRepository _farmsRepository;

        public FarmsService(IFarmsRepository farmsRepository)
        {
            _farmsRepository = farmsRepository;
        }

        public async Task<List<Farms>> GetFarms()
        {
            return await _farmsRepository.GetFarms();
        }

        public async Task<Farms> GetFarmId(int id)
        {
            return await _farmsRepository.GetFarmId(id);
        }

        public async Task<Farms> AddFarm(string FarmName)
        {
            return await _farmsRepository.AddFarm(FarmName);
        }

        public async Task<Farms> UpdateFarm(int FarmId, string? FarmName = null)
        {
            var farm = await _farmsRepository.GetFarmId(FarmId);
            if (farm == null)
            {
                throw new Exception("Farm not found");
            }

            if (FarmName != null)
            {
                farm.FarmName = FarmName;
            }

            return await _farmsRepository.UpdateFarm(farm);
        }

        public async Task<Farms> DeleteFarm(int id)
        {
            return await _farmsRepository.DeleteFarm(id);
        }
    }
}
