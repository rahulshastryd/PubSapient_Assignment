
namespace Pharmacy.Application.DTOs
{
    public record CreateMedicineDto(
    string Name,
    string Brand,
    string Notes,
    DateTime ExpiryDate,
    int Quantity,
    decimal Price);
}