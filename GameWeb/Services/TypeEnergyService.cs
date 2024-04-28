using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface ITypeEnergyService
    {
        Task<List<TypeEnergy>> GetTypeEnergy();
        Task<TypeEnergy> GetTypeEnergyId(int id);
        Task<TypeEnergy> AddTypeEnergy(string TypeEnergyName);
        Task<TypeEnergy> UpdateTypeEnergy(int TypeEnergyId, string? TypeEnergyName = null);
        Task<TypeEnergy> DeleteTypeEnergy(int id);
    }
    public class TypeEnergyService: ITypeEnergyService
    {
        private readonly ITypeEnergyRepository _typeEnergyRepository;

        public TypeEnergyService(ITypeEnergyRepository typeEnergyRepository)
        {
            _typeEnergyRepository = typeEnergyRepository;
        }

        public async Task<List<TypeEnergy>> GetTypeEnergy()
        {
            return await _typeEnergyRepository.GetTypeEnergy();
        }

        public async Task<TypeEnergy> GetTypeEnergyId(int id)
        {
            return await _typeEnergyRepository.GetTypeEnergyId(id);
        }

        public async Task<TypeEnergy> AddTypeEnergy(string TypeEnergyName)
        {
            return await _typeEnergyRepository.AddTypeEnergy(TypeEnergyName);
        }

        public async Task<TypeEnergy> UpdateTypeEnergy(int TypeEnergyId, string? TypeEnergyName = null)
        {
            var typeEnergy = await _typeEnergyRepository.GetTypeEnergyId(TypeEnergyId);
            if (typeEnergy == null)
            {
                throw new Exception("TypeEnergy not found");
            }

            if (TypeEnergyName != null)
            {
                typeEnergy.TypeEnergyName = TypeEnergyName;
            }

            return await _typeEnergyRepository.UpdateTypeEnergy(typeEnergy);
        }

        public async Task<TypeEnergy> DeleteTypeEnergy(int id)
        {
            return await _typeEnergyRepository.DeleteTypeEnergy(id);
        }
    }
}
