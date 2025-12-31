using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Pharmacy.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public Guid MedicineId { get; private set; }
        public int QuantitySold { get; private set; }
        public DateTime SoldOn { get; private set; }

        [JsonConstructor]
        private Sale(Guid id, Guid medicineId, int quantitySold, DateTime soldOn)
        {
            Id = id;
            MedicineId = medicineId;
            QuantitySold = quantitySold;
            SoldOn = soldOn;
        }

        public Sale(Guid medicineId, int quantitySold)
        {
            Id = Guid.NewGuid();
            MedicineId = medicineId;
            QuantitySold = quantitySold;
            SoldOn = DateTime.UtcNow;
        }
    }
}
