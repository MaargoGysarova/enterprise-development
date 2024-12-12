namespace PharmacyManagementSystem.Api.Dto;
    /// <summary>
    /// DTO для представления типа условий оплаты
    /// </summary>
    public class PaymentConditionsTypeDto
    {
        /// <summary>
        /// Код типа оплаты
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя типа оплаты
        /// </summary>
        public required string Value { get; set; }
    }

