using System;
using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Api.Dto
{
    /// <summary>
    /// DTO для получения информации о записи в прайс-листе
    /// </summary>
    public class PriceListGetDto
    {
        /// <summary>
        /// Уникальный идентификатор прайс-листа
        /// </summary>
        public required int PriceListId { get; set; }

        /// <summary>
        /// Идентификатор аптеки
        /// </summary>
        public required int PharmacyId { get; set; }

        /// <summary>
        /// Название аптеки
        /// </summary>
        public required string PharmacyName { get; set; }

        /// <summary>
        /// Идентификатор препарата
        /// </summary>
        public required int MedicineId { get; set; }

        /// <summary>
        /// Наименование препарата
        /// </summary>
        public required string MedicineName { get; set; }

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
}
