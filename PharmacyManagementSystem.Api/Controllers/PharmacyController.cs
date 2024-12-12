using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Api.Service;
using System.Collections.Generic;

namespace PharmacyManagementSystem.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с аптеками.
    /// Предоставляет методы для получения, добавления, обновления и удаления аптек.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
     public class PharmacyController(PharmacyService pharmacyService) : ControllerBase
    {
        private readonly PharmacyService _pharmacyService = pharmacyService;

        /// <summary>
        /// Получить все аптеки.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<PharmacyGetDto>> GetAll()
        {
            var pharmacies = _pharmacyService.GetAll();
            return Ok(pharmacies);
        }

        /// <summary>
        /// Получить аптеку по ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<PharmacyGetDto> GetById(int id)
        {
            var pharmacy = _pharmacyService.GetById(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return Ok(pharmacy);
        }

        /// <summary>
        /// Создать новую аптеку.
        /// </summary>
        [HttpPost]
        public ActionResult<int> Post([FromBody] PharmacyPostDto pharmacyDto)
        {
            var pharmacyId = _pharmacyService.Post(pharmacyDto);
            return CreatedAtAction(nameof(GetById), new { id = pharmacyId }, pharmacyId);
        }

        /// <summary>
        /// Обновить аптеку.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<PharmacyGetDto> Put(int id, [FromBody] PharmacyPostDto pharmacyDto)
        {
            var updatedPharmacy = _pharmacyService.Put(id, pharmacyDto);
            if (updatedPharmacy == null)
            {
                return NotFound();
            }
            return Ok(updatedPharmacy);
        }

        /// <summary>
        /// Удалить аптеку.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _pharmacyService.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
