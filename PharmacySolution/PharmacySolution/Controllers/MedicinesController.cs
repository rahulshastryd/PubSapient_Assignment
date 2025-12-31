using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.DTOs;
using Pharmacy.Application.Interfaces;
using Pharmacy.Application.Validators;
using Pharmacy.Domain.Entities;

namespace Pharmacy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepository _repository;

        public MedicinesController(IMedicineRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? search)
        {
            var medicines = await _repository.GetAllAsync(search);

            var result = medicines.Select(m => new MedicineDto(
                m.Id,
                m.Name,
                m.Brand,
                m.ExpiryDate,
                m.Quantity,
                m.Price
            ));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMedicineDto dto)
        {
            CreateMedicineValidator.Validate(dto);

            var medicine = new Medicine(
                dto.Name,
                dto.Brand,
                dto.Notes,
                dto.ExpiryDate,
                dto.Quantity,
                dto.Price
            );

            await _repository.AddAsync(medicine);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMedicineDto dto)
        {
            var medicine = await _repository.GetByIdAsync(id);
            if (medicine == null)
                return NotFound();

            medicine.UpdateDetails(
                dto.Name,
                dto.Brand,
                dto.Notes,
                dto.ExpiryDate,
                dto.Quantity,
                dto.Price
            );

            await _repository.UpdateAsync(medicine);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }


    }
}
