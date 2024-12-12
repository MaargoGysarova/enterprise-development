using System;
using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Api.Dto;

    /// <summary>
    /// DTO для создания или обновления записи в прайс-листе
    /// </summary>
    public class PriceListPostDto
    {
        /// <summary>
        /// Идентификатор аптеки
        /// </summary>
        public required int PharmacyId { get; set; }

        /// <summary>
        /// Идентификатор препарата
        /// </summary>
        public required int MedicineId { get; set; }

        /// <summary>
        /// Изготовитель препарата
        /// </summary>
        public required string Manufacturer { get; set; }

        /// <summary>
        /// Условия оплаты (наличные/безналичные)
        /// </summary>
        public required PaymentConditionsType PaymentConditions { get; set; }

        /// <summary>
        /// Реализующая фирма (поставщик)
        /// </summary>
        public string? Supplier { get; set; }

        /// <summary>
        /// Стоимость препарата
        /// </summary>
        public required decimal Price { get; set; }

        /// <summary>
        /// Дата продажи
        /// </summary>
        public required DateTime SaleDate { get; set; }
    }

