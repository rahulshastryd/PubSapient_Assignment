using Pharmacy.Application.Interfaces;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Pharmacy.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly string _filePath = "Data/sales.json";

        public async Task AddAsync(Sale sale)
        {
            var sales = await GetAllAsync();
            sales.Add(sale);

            Directory.CreateDirectory("Data");
            await File.WriteAllTextAsync(
                _filePath,
                JsonSerializer.Serialize(sales, new JsonSerializerOptions { WriteIndented = true })
            );
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Sale>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Sale>>(json) ?? [];
        }
    }

}
