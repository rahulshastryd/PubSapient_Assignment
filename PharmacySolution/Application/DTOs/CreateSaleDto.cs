using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Application.DTOs
{
    public record CreateSaleDto(
    Guid MedicineId,
    int Quantity
    );

}
