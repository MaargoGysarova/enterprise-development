using System.Collections.Generic;
using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Api.Dto
{
    /// <summary>
    /// DTO для получения информации о препарате
    /// </summary>
    public class MedicineGetDto
    {
        /// <summary>
        /// Уникальный идентификатор препарата
        /// </summary>
        public required int MedicineId { get; set; }

        /// <summary>
        /// Наименование препарата
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Товарная группа препарата
        /// </summary>
        public required ProductGroupType ProductGroup { get; set; }

        /// <summary>
        /// Фармацевтические группы препарата
        /// </summary>
        public List<PharmaceuticalGroupType> PharmaceuticalGroups { get; set; }

        /// <summary>
        /// Количество штук препарата
        /// </summary>
        public required int Quantity { get; set; }
    }
}
