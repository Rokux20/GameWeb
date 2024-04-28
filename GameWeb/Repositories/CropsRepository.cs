using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface ICropsRepository
    {
        Task<List<Crops>> GetCrops();
        Task<Crops> GetCropId(int id);
        Task<Crops> AddCrop(string CropName, int Farmid);
        Task<Crops> UpdateCrop(Crops crop);
        Task<Crops> DeleteCrop(int id);
    }
    public class CropsRepository : ICropsRepository
    {
        private readonly FarmDbContext _context;

        public CropsRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Crops>> GetCrops()
        {
            return await _context.Crops.ToListAsync();
        }

        public async Task<Crops> GetCropId(int id)
        {
            return await _context.Crops.FindAsync(id);
        }

        public async Task<Crops> AddCrop(string CropName, int Farmid)
        {
            var crop = new Crops
            {
                CropName = CropName,
                FarmId = Farmid
            };

            await _context.Crops.AddAsync(crop);
            _context.SaveChanges();
            return crop;
        }

        public async Task<Crops> UpdateCrop(Crops crop)
        {
            _context.Entry(crop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return crop;
        }

        public async Task<Crops> DeleteCrop(int id)
        {
            var crop = await _context.Crops.FindAsync(id);
            if (crop == null)
            {
                return null;
            }

            _context.Crops.Remove(crop);
            await _context.SaveChangesAsync();
            return crop;
        }
    }

}
