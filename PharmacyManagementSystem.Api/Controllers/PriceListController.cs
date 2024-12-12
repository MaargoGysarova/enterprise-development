using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Api.Service;
using System.Collections.Generic;

namespace PharmacyManagementSystem.Api.Controllers;
    /// <summary>
    /// Контроллер для работы с прайс-листами.
    /// Предоставляет методы для получения, добавления, обновления и удаления прайс-листов.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PriceListController(IService<PriceListGetDto, PriceListPostDto> priceListService) : ControllerBase
    {
        private readonly IService<PriceListGetDto, PriceListPostDto> _priceListService = priceListService;


        /// <summary>
        /// Получить все прайс-листы.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<PriceListGetDto>> GetAll()
        {
            var priceLists = _priceListService.GetAll();
            return Ok(priceLists);
        }

        /// <summary>
        /// Получить прайс-лист по ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<PriceListGetDto> GetById(int id)
        {
            var priceList = _priceListService.GetById(id);
            if (priceList == null)
            {
                return NotFound();
            }
            return Ok(priceList);
        }

        /// <summary>
        /// Создать новый прайс-лист.
        /// </summary>
        [HttpPost]
        public ActionResult<int> Post([FromBody] PriceListPostDto priceListDto)
        {
            var priceListId = _priceListService.Post(priceListDto);
            return CreatedAtAction(nameof(GetById), new { id = priceListId }, priceListId);
        }

        /// <summary>
        /// Обновить прайс-лист.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<PriceListGetDto> Put(int id, [FromBody] PriceListPostDto priceListDto)
        {
            var updatedPriceList = _priceListService.Put(id, priceListDto);
            if (updatedPriceList == null)
            {
                return NotFound();
            }
            return Ok(updatedPriceList);
        }

        /// <summary>
        /// Удалить прайс-лист.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _priceListService.Delete(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
