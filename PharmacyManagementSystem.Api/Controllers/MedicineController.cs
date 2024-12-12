using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Api.Service;
using System.Collections.Generic;

namespace PharmacyManagementSystem.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с препаратами.
    /// Предоставляет методы для получения, добавления, обновления и удаления препаратов.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MedicineController(MedicineService medicineService) : ControllerBase
    {
        private readonly MedicineService _medicineService = medicineService;


        /// <summary>
        /// Получить все препараты.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<MedicineGetDto>> GetAll()
        {
            var medicines = _medicineService.GetAll();
            return Ok(medicines);
        }

        /// <summary>
        /// Получить препарат по ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<MedicineGetDto> GetById(int id)
        {
            var medicine = _medicineService.GetById(id);
            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }

        /// <summary>
        /// Создать новый препарат.
        /// </summary>
        [HttpPost]
        public ActionResult<int> Post([FromBody] MedicinePostDto medicineDto)
        {
            var medicineId = _medicineService.Post(medicineDto);
            return CreatedAtAction(nameof(GetById), new { id = medicineId }, medicineId);
        }

        /// <summary>
        /// Обновить препарат.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<MedicineGetDto> Put(int id, [FromBody] MedicinePostDto medicineDto)
        {
            var updatedMedicine = _medicineService.Put(id, medicineDto);
            if (updatedMedicine == null)
            {
                return NotFound();
            }
            return Ok(updatedMedicine);
        }

        /// <summary>
        /// Удалить препарат.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _medicineService.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
