using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.DTOs;
using Pharmacy.Application.Interfaces;
using Pharmacy.Domain.Entities;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepo;
        private readonly ISaleRepository _saleRepo;

        public SalesController(
            IMedicineRepository medicineRepo,
            ISaleRepository saleRepo)
        {
            _medicineRepo = medicineRepo;
            _saleRepo = saleRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Sell(CreateSaleDto dto)
        {
            var medicine = await _medicineRepo.GetByIdAsync(dto.MedicineId);
            if (medicine == null)
                return NotFound("Medicine not found");

            medicine.ReduceStock(dto.Quantity);

            await _medicineRepo.UpdateAsync(medicine);
            await _saleRepo.AddAsync(new Sale(dto.MedicineId, dto.Quantity));

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sales = await _saleRepo.GetAllAsync();
            return Ok(sales);
        }

    }
}
