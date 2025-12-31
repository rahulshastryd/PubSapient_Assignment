using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Application.Interfaces
{
    public interface ISaleRepository
    {
        Task AddAsync(Sale sale);
        Task<List<Sale>> GetAllAsync();
    }
}
