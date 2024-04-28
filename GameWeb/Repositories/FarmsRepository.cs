using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface IFarmsRepository
    {
        Task<List<Farms>> GetFarms();
        Task<Farms> GetFarmId(int id);
        Task<Farms> AddFarm(string FarmName);
        Task<Farms> UpdateFarm(Farms farm);
        Task<Farms> DeleteFarm(int id);
    }
    public class FarmsRepository : IFarmsRepository
    {
        private readonly FarmDbContext _context;

        public FarmsRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<Farms>> GetFarms()
        {
            return await _context.Farms.ToListAsync();
        }

        public async Task<Farms> GetFarmId(int id)
        {
            return await _context.Farms.FindAsync(id);
        }

        public async Task<Farms> AddFarm(string FarmName)
        {
            var farm = new Farms
            {
                FarmName = FarmName
            };

            await _context.Farms.AddAsync(farm);
            _context.SaveChanges();
            return farm;
        }

        public async Task<Farms> UpdateFarm(Farms farm)
        {
            _context.Entry(farm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return farm;
        }

        public async Task<Farms> DeleteFarm(int id)
        {
            var farm = await _context.Farms.FindAsync(id);
            if (farm == null)
            {
                return null;
            }

            _context.Farms.Remove(farm);
            await _context.SaveChangesAsync();
            return farm;
        }
    }
}
