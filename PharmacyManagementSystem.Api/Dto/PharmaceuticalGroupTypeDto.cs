namespace PharmacyManagementSystem.Api.Dto;
    /// <summary>
    /// DTO для передачи фармацевтической группы препарата
    /// </summary>
    public class PharmaceuticalGroupTypeDto
    {
        /// <summary>
        /// Строковое представление фармацевтической группы
        /// </summary>
        public required string Value { get; set; }
    }

