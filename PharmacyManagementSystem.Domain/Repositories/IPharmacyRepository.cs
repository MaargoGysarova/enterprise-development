namespace PharmacyManagementSystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с аптечными данными.
    /// Реализует методы для выполнения операций CRUD с аптеками.
    /// </summary>
    public class IPharmacyRepository : IRepository<Pharmacy>
    {
        private readonly List<Pharmacy> _pharmacies;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с пустым списком аптек.
        /// </summary>
        public IPharmacyRepository()
        {
            _pharmacies = new List<Pharmacy>(); // Инициализируем пустой список аптек
        }

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с заданным списком аптек.
        /// </summary>
        /// <param name="pharmacyList">Список аптек для инициализации репозитория</param>
        public IPharmacyRepository(List<Pharmacy> pharmacyList)
        {
            _pharmacies = pharmacyList; // Инициализируем репозиторий переданным списком аптек
        }

        /// <summary>
        /// Получает все аптеки из репозитория.
        /// </summary>
        /// <returns>Перечень всех аптек в репозитории</returns>
        public IEnumerable<Pharmacy> GetAll()
        {
            return _pharmacies;
        }

        /// <summary>
        /// Получает аптеку по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор аптеки</param>
        /// <returns>Найдена ли аптека. Если найдена, возвращает аптеку, иначе null</returns>
        public Pharmacy? GetById(int id)
        {
            return _pharmacies.FirstOrDefault(p => p.PharmacyId == id);
        }

        /// <summary>
        /// Добавляет новую аптеку в репозиторий.
        /// </summary>
        /// <param name="pharmacy">Новая аптека для добавления в репозиторий</param>
        /// <returns>Возвращает ID новой аптеки</returns>
        public int Post(Pharmacy pharmacy)
        {
            var newId = _pharmacies.Count > 0 ? _pharmacies.Max(p => p.PharmacyId) + 1 : 1;
            pharmacy.PharmacyId = newId;
            _pharmacies.Add(pharmacy); // Добавляем аптеку в список
            return newId;
        }

        /// <summary>
        /// Обновляет информацию об аптеке в репозитории.
        /// </summary>
        /// <param name="pharmacy">Аптека с обновленными данными</param>
        /// <returns>Возвращает true, если аптека была успешно обновлена, иначе false</returns>
        public bool Put(Pharmacy pharmacy)
        {
            var existingPharmacy = GetById(pharmacy.PharmacyId);
            if (existingPharmacy == null)
                return false;

            existingPharmacy.Name = pharmacy.Name;
            existingPharmacy.Address = pharmacy.Address;
            return true;
        }

        /// <summary>
        /// Удаляет аптеку из репозитория по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор аптеки для удаления</param>
        /// <returns>Возвращает true, если аптека была успешно удалена, иначе false</returns>
        public bool Delete(int id)
        {
            var pharmacy = GetById(id);
            if (pharmacy == null)
                return false;

            _pharmacies.Remove(pharmacy); // Удаляем аптеку из списка
            return true;
        }
    }
}
