using PharmacyManagementSystem.Enums;

namespace PharmacyManagementSystem;

/// <summary>
/// Класс, представляющий аптеку
/// </summary>
public class Pharmacy
{
    /// <summary>
    /// Уникальный идентификатор аптеки (первичный ключ)
    /// </summary>
    public int PharmacyId { get; set; }
    
    /// <summary>
    /// Название аптеки
    /// </summary>
    public required string Name { get; set; } 
    
    /// <summary>
    /// Номер телефона аптеки
    /// </summary>
    public string? PhoneNumber { get; set; } // Может быть null, если номер телефона отсутствует
    
    /// <summary>
    /// Адрес аптеки
    /// </summary>
    public required string Address { get; set; } 
    
    /// <summary>
    /// ФИО директора аптеки
    /// </summary>
    public string? DirectorFullName { get; set; } // Может быть null, если директор временно отсутствует
    
    /// <summary>
    /// Прайс-листы, связанные с аптекой
    /// </summary>
    public required ICollection<PriceList> PriceLists { get; set; } = new List<PriceList>(); // Обязательное свойство
}
