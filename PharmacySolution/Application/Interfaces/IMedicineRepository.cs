using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Interfaces
{
    public interface IMedicineRepository
    {

        Task<List<Medicine>> GetAllAsync(string? search);
        Task AddAsync(Medicine medicine);
        Task<Medicine?> GetByIdAsync(Guid id);
        Task UpdateAsync(Medicine medicine);
        Task DeleteAsync(Guid id);
    }
}

