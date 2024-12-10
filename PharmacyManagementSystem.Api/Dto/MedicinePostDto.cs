using PharmacyManagementSystem.Domain.Enums;
using System.Collections.Generic;


namespace PharmacyManagementSystem.Api.Dto
{
    /// <summary>
    /// DTO для создания или обновления информации о препарате
    /// </summary>
    public class MedicinePostDto
    {
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
        public List<PharmaceuticalGroupType> PharmaceuticalGroups { get; set; } = new List<PharmaceuticalGroupType>();

        /// <summary>
        /// Количество штук препарата
        /// </summary>
        public required int Quantity { get; set; }
    }
}
