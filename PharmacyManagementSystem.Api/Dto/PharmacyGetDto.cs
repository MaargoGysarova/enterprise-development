using System.Collections.Generic;

namespace PharmacyManagementSystem.Api.Dto;

    /// <summary>
    /// DTO для получения информации об аптеке
    /// </summary>
    public class PharmacyGetDto
    {
        /// <summary>
        /// Уникальный идентификатор аптеки
        /// </summary>
        public required int PharmacyId { get; set; }

        /// <summary>
        /// Название аптеки
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Номер телефона аптеки (может быть пустым, если не указан)
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Адрес аптеки
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// ФИО директора аптеки (может быть пустым, если не указано)
        /// </summary>
        public string? DirectorFullName { get; set; }

        /// <summary>
        /// Список имен прайс-листов, связанных с аптекой
        /// </summary>
        public required List<string> PriceListNames { get; set; } = new List<string>();
    }

