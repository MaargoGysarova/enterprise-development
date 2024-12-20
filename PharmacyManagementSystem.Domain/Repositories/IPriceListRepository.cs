using PharmacyManagementSystem.Domain.Data;

namespace PharmacyManagementSystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными прайс-листов.
    /// Реализует методы для выполнения операций CRUD с прайс-листами.
    /// </summary>
    public class IPriceListRepository : IRepository<PriceList>
    {
         private readonly PharmacyDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с контекстом базы данных.
        /// </summary>
        public IPriceListRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает все прайс-листы из репозитория.
        /// </summary>
        /// <returns>Перечень всех прайс-листов в репозитории</returns>
        public IEnumerable<PriceList> GetAll()
        {
            return _context.PriceLists.ToList();
        }

        /// <summary>
        /// Получает прайс-лист по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор прайс-листа</param>
        /// <returns>Найдена ли запись. Если найдена, возвращает прайс-лист, иначе null</returns>
        public PriceList? GetById(int id)
        {
            return _context.PriceLists.Find(id);
        }

        /// <summary>
        /// Добавляет новый прайс-лист в репозиторий.
        /// </summary>
        /// <param name="priceList">Новый прайс-лист для добавления в репозиторий</param>
        /// <returns>Возвращает ID нового прайс-листа</returns>
        public int Post(PriceList priceList)
        {
             _context.PriceLists.Add(priceList);
            _context.SaveChanges();
            return priceList.PriceListId;
        }

        /// <summary>
        /// Обновляет информацию о существующем прайс-листе в репозитории.
        /// </summary>
        /// <param name="priceList">Прайс-лист с обновленными данными</param>
        /// <returns>Возвращает true, если прайс-лист был успешно обновлен, иначе false</returns>
        public bool Put(PriceList priceList)
        {
            var existingPriceList = _context.PriceLists.Find(priceList.PriceListId);
            if (existingPriceList == null)
                return false;

            // Обновляем значения
            existingPriceList.Manufacturer = priceList.Manufacturer;
            existingPriceList.Price = priceList.Price;
            existingPriceList.PharmacyId = priceList.PharmacyId;
            existingPriceList.MedicineId = priceList.MedicineId;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет прайс-лист из репозитория по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор прайс-листа для удаления</param>
        /// <returns>Возвращает true, если прайс-лист был успешно удален, иначе false</returns>
        public bool Delete(int id)
        {
            var priceList = _context.PriceLists.Find(id);
            if (priceList == null)
                return false;

            _context.PriceLists.Remove(priceList);
            _context.SaveChanges();
            return true;
        }
    }
}
