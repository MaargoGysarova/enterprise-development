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
    public string Name { get; set; } 
    
    /// <summary>
    /// Номер телефона аптеки
    /// </summary>
    public string PhoneNumber { get; set; } 
    
    /// <summary>
    /// Адрес аптеки
    /// </summary>
    public string Address { get; set; } 
    
    /// <summary>
    /// ФИО директора аптеки
    /// </summary>
    public string DirectorFullName { get; set; }
    
    /// <summary>
    /// Прайс-листы, связанные с аптекой
    /// </summary>
    public ICollection<PriceList> PriceLists { get; set; } = new List<PriceList>();
}