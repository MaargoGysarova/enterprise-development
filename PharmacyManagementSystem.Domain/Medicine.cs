using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Domain;

/// <summary>
/// Класс, представляющий препарат
/// </summary>
public class Medicine
{
    /// <summary>
    /// Уникальный идентификатор препарата (первичный ключ)
    /// </summary>
    public required int MedicineId { get; set; }
    
    /// <summary>
    /// Наименование препарата
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Товарная группа препарата
    /// </summary>
    public required ProductGroupType ProductGroup { get; set; } // Используем enum для товарной группы вместо строки
    
    /// <summary>
    /// Фармацевтические группы препарата (может быть несколько)
    /// </summary>
    public List<PharmaceuticalGroupType> PharmaceuticalGroups { get; set; } = new List<PharmaceuticalGroupType>(); // Используем enum для фармацевтической группы. Не nullable, так как инициализируем пустым списком по умолчанию
    
    /// <summary>
    /// Количество штук препарата
    /// </summary>
    public required int Quantity { get; set; }
}
