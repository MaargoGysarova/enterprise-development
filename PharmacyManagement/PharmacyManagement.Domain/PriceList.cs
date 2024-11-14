using PharmacyManagementSystem.Enums;

namespace PharmacyManagementSystem;

/// <summary>
/// Класс, представляющий запись в прайс-листе
/// </summary>
public class PriceList
{
    /// <summary>
    /// Уникальный идентификатор прайс-листа (первичный ключ)
    /// </summary>
    public int PriceListId { get; set; }

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public int PharmacyId { get; set; }

    /// <summary>
    /// Ссылка на аптеку
    /// </summary>
    public Pharmacy Pharmacy { get; set; }

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int MedicineId { get; set; }

    /// <summary>
    /// Ссылка на препарат
    /// </summary>
    public Medicine Medicine { get; set; }

    /// <summary>
    /// Изготовитель препарата
    /// </summary>
    public string Manufacturer { get; set; }

    /// <summary>
    /// Условия оплаты (наличные/безналичные)
    /// </summary>
    public PaymentConditionsType PaymentConditions { get; set; } // Используем enum для условий оплаты вместо строки

    /// <summary>
    /// Реализующая фирма (поставщик)
    /// </summary>
    public string Supplier { get; set; }

    /// <summary>
    /// Стоимость препарата
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Дата продажи
    /// </summary>
    public DateTime SaleDate { get; set; }
}
