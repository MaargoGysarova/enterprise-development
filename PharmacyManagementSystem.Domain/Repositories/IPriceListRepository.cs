namespace PharmacyManagementSystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными прайс-листов.
    /// Реализует методы для выполнения операций CRUD с прайс-листами.
    /// </summary>
    public class IPriceListRepository : IRepository<PriceList>
    {
        private readonly List<PriceList> _priceLists;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с пустым списком прайс-листов.
        /// </summary>
        public IPriceListRepository()
        {
            _priceLists = new List<PriceList>(); // Пустой список прайс-листов
        }

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с заданным списком прайс-листов.
        /// </summary>
        /// <param name="priceList">Список прайс-листов для инициализации репозитория</param>
        public IPriceListRepository(List<PriceList> priceList)
        {
            _priceLists = priceList; // Инициализация репозитория переданным списком
        }

        /// <summary>
        /// Получает все прайс-листы из репозитория.
        /// </summary>
        /// <returns>Перечень всех прайс-листов в репозитории</returns>
        public IEnumerable<PriceList> GetAll()
        {
            return _priceLists;
        }

        /// <summary>
        /// Получает прайс-лист по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор прайс-листа</param>
        /// <returns>Найдена ли запись. Если найдена, возвращает прайс-лист, иначе null</returns>
        public PriceList? GetById(int id)
        {
            return _priceLists.FirstOrDefault(p => p.PriceListId == id);
        }

        /// <summary>
        /// Добавляет новый прайс-лист в репозиторий.
        /// </summary>
        /// <param name="priceList">Новый прайс-лист для добавления в репозиторий</param>
        /// <returns>Возвращает ID нового прайс-листа</returns>
        public int Post(PriceList priceList)
        {
            var newId = _priceLists.Count > 0 ? _priceLists.Max(p => p.PriceListId) + 1 : 1;
            priceList.PriceListId = newId;
            _priceLists.Add(priceList); // Добавляем новый прайс-лист в список
            return newId;
        }

        /// <summary>
        /// Обновляет информацию о существующем прайс-листе в репозитории.
        /// </summary>
        /// <param name="priceList">Прайс-лист с обновленными данными</param>
        /// <returns>Возвращает true, если прайс-лист был успешно обновлен, иначе false</returns>
        public bool Put(PriceList priceList)
        {
            var existingPriceList = GetById(priceList.PriceListId);
            if (existingPriceList == null)
                return false;

            existingPriceList.Manufacturer = priceList.Manufacturer;
            existingPriceList.Price = priceList.Price;
            return true;
        }

        /// <summary>
        /// Удаляет прайс-лист из репозитория по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор прайс-листа для удаления</param>
        /// <returns>Возвращает true, если прайс-лист был успешно удален, иначе false</returns>
        public bool Delete(int id)
        {
            var priceList = GetById(id);
            if (priceList == null)
                return false;

            _priceLists.Remove(priceList); // Удаляем прайс-лист из списка
            return true;
        }
    }
}
