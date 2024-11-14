using PharmacyManagementSystem.Enums;

namespace PharmacyManagementSystem;

/// <summary>
/// Класс, представляющий препарат
/// </summary>
public class Medicine
{
    /// <summary>
    /// Уникальный идентификатор препарата (первичный ключ)
    /// </summary>
    public int MedicineId { get; set; }
    
    /// <summary>
    /// Наименование препарата
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Товарная группа препарата
    /// </summary>
    public ProductGroupType ProductGroup { get; set; } // Используем enum для товарной группы вместо строки
    
    /// <summary>
    /// Фармацевтические группы препарата (может быть несколько)
    /// </summary>
    public List<PharmaceuticalGroupType> PharmaceuticalGroups { get; set; } = new List<PharmaceuticalGroupType>(); // Используем enum для фармацевтической группы
    
    /// <summary>
    /// Количество штук препарата
    /// </summary>
    public int Quantity { get; set; }
}
