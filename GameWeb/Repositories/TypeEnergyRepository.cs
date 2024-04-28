using GameWeb.Context;
using GameWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameWeb.Repositories
{
    public interface ITypeEnergyRepository
    {
        Task<List<TypeEnergy>> GetTypeEnergy();
        Task<TypeEnergy> GetTypeEnergyId(int id);
        Task<TypeEnergy> AddTypeEnergy(string TypeEnergyName);
        Task<TypeEnergy> UpdateTypeEnergy(TypeEnergy typeEnergy);
        Task<TypeEnergy> DeleteTypeEnergy(int id);
    }
    public class TypeEnergyRepository : ITypeEnergyRepository
    {
        private readonly FarmDbContext _context;

        public TypeEnergyRepository(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<List<TypeEnergy>> GetTypeEnergy()
        {
            return await _context.TypeEnergy.ToListAsync();
        }

        public async Task<TypeEnergy> GetTypeEnergyId(int id)
        {
            return await _context.TypeEnergy.FindAsync(id);
        }

        public async Task<TypeEnergy> AddTypeEnergy(string TypeEnergyName)
        {
            var typeEnergy = new TypeEnergy
            {
                TypeEnergyName = TypeEnergyName
            };

            await _context.TypeEnergy.AddAsync(typeEnergy);
            _context.SaveChanges();
            return typeEnergy;
        }

        public async Task<TypeEnergy> UpdateTypeEnergy(TypeEnergy typeEnergy)
        {
            _context.Entry(typeEnergy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return typeEnergy;
        }

        public async Task<TypeEnergy> DeleteTypeEnergy(int id)
        {
            var typeEnergy = await _context.TypeEnergy.FindAsync(id);
            if (typeEnergy == null)
            {
                return null;
            }

            _context.TypeEnergy.Remove(typeEnergy);
            await _context.SaveChangesAsync();
            return typeEnergy;
        }
    }
}
