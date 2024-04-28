using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface ICropsService
    {
        Task<List<Crops>> GetCrops();
        Task<Crops> GetCropId(int id);
        Task<Crops> AddCrop(string CropName, int FarmId);
        Task<Crops> UpdateCrop(int CropId, string? CropName = null, int? FarmId = null);
        Task<Crops> DeleteCrop(int id);
    }
    public class CropsService : ICropsService
    {
        private readonly ICropsRepository _cropsRepository;

        public CropsService(ICropsRepository cropsRepository)
        {
            _cropsRepository = cropsRepository;
        }

        public async Task<List<Crops>> GetCrops()
        {
            return await _cropsRepository.GetCrops();
        }

        public async Task<Crops> GetCropId(int id)
        {
            return await _cropsRepository.GetCropId(id);
        }

        public async Task<Crops> AddCrop(string CropName, int FarmId)
        {
            return await _cropsRepository.AddCrop(CropName, FarmId);
        }

        public async Task<Crops> UpdateCrop(int CropId, string? CropName = null, int? FarmId = null)
        {
            var crop = await _cropsRepository.GetCropId(CropId);
            if (crop == null)
            {
                throw new Exception("Crop not found");
            }

            if (CropName != null)
            {
                crop.CropName = CropName;
            }

            if (FarmId != null)
            {
                crop.FarmId = (int)FarmId;
            }

            return await _cropsRepository.UpdateCrop(crop);
        }

        public async Task<Crops> DeleteCrop(int id)
        {
            return await _cropsRepository.DeleteCrop(id);
        }
    }
}
