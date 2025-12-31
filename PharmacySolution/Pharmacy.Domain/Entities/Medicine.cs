using System.Text.Json.Serialization;

namespace Pharmacy.Domain.Entities
{
    using System.Text.Json.Serialization;

    public class Medicine
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Brand { get; private set; } = default!;
        public string Notes { get; private set; } = default!;
        public DateTime ExpiryDate { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        // Used by JSON deserializer
        [JsonConstructor]
        private Medicine(
            Guid id,
            string name,
            string brand,
            string notes,
            DateTime expiryDate,
            int quantity,
            decimal price)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Notes = notes;
            ExpiryDate = expiryDate;
            Quantity = quantity;
            Price = price;
        }

        // Used by application when creating new medicine
        public Medicine(
            string name,
            string brand,
            string notes,
            DateTime expiryDate,
            int quantity,
            decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Brand = brand;
            Notes = notes;
            ExpiryDate = expiryDate;
            Quantity = quantity;
            Price = price;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Invalid sale quantity");

            if (Quantity < quantity)
                throw new InvalidOperationException("Insufficient stock");

            Quantity -= quantity;
        }
    }


}

