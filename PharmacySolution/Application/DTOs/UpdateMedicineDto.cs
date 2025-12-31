using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Application.DTOs
{
    public record UpdateMedicineDto(
    string Name,
    string Brand,
    string Notes,
    DateTime ExpiryDate,
    int Quantity,
    decimal Price);
}
