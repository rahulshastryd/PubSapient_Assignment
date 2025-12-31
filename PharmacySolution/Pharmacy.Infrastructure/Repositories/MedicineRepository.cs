using System.Text.Json;
using Pharmacy.Domain.Entities;
using Pharmacy.Application.Interfaces;

namespace Pharmacy.Infrastructure.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly string _filePath = "Data/medicines.json";

        public async Task<List<Medicine>> GetAllAsync(string? search)
        {
            if (!File.Exists(_filePath))
                return new List<Medicine>();

            var json = await File.ReadAllTextAsync(_filePath);
            var medicines = JsonSerializer.Deserialize<List<Medicine>>(json) ?? [];

            if (!string.IsNullOrWhiteSpace(search))
            {
                medicines = medicines
                    .Where(m => m.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return medicines;
        }

        public async Task AddAsync(Medicine medicine)
        {
            var medicines = await GetAllAsync(null);
            medicines.Add(medicine);

            Directory.CreateDirectory("Data");

            await File.WriteAllTextAsync(
                _filePath,
                JsonSerializer.Serialize(medicines, new JsonSerializerOptions { WriteIndented = true })
            );
        }

        public async Task<Medicine?> GetByIdAsync(Guid id)
        {
            var medicines = await GetAllAsync(null);
            return medicines.FirstOrDefault(m => m.Id == id);
        }

        public async Task UpdateAsync(Medicine medicine)
        {
            var medicines = await GetAllAsync(null);

            var index = medicines.FindIndex(m => m.Id == medicine.Id);
            if (index == -1)
                throw new Exception("Medicine not found");

            medicines[index] = medicine;

            await File.WriteAllTextAsync(
                _filePath,
                JsonSerializer.Serialize(medicines, new JsonSerializerOptions
                {
                    WriteIndented = true
                })
            );
        }

        public async Task DeleteAsync(Guid id)
        {
            var medicines = await GetAllAsync(null);

            var updated = medicines.Where(m => m.Id != id).ToList();

            await File.WriteAllTextAsync(
                _filePath,
                JsonSerializer.Serialize(updated, new JsonSerializerOptions
                {
                    WriteIndented = true
                })
            );
        }


    }
}