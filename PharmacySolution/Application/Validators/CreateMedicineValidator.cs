using Pharmacy.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Application.Validators
{
    public static class CreateMedicineValidator
    {
        public static void Validate(CreateMedicineDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Medicine name is required");

            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            if (dto.Quantity < 0)
                throw new ArgumentException("Quantity cannot be negative");

            if (dto.ExpiryDate <= DateTime.UtcNow.Date)
                throw new ArgumentException("Expiry date must be in the future");
        }
    }
}
