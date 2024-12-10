namespace PharmacyManagementSystem.Api.Dto
{
    /// <summary>
    /// DTO для создания или обновления информации об аптеке
    /// </summary>
    public class PharmacyPostDto
    {
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
    }
}
