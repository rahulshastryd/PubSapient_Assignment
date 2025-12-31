namespace Pharmacy.Application.DTOs
{
    public record MedicineDto(
    Guid Id,
    string Name,
    string Brand,
    DateTime ExpiryDate,
    int Quantity,
    decimal Price
);

}