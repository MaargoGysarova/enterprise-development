namespace PharmacyManagementSystem.Api.Dto;
    /// <summary>
    /// DTO для передачи товарной группы препарата
    /// </summary>
    public class ProductGroupTypeDto
    {
        /// <summary>
        /// Название товарной группы препарата.
        /// </summary>
        public required string Value { get; set; }
    }
