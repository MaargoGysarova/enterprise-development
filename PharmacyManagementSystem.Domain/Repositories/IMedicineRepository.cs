namespace PharmacyManagementSystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными о лекарствах.
    /// Реализует методы для выполнения операций CRUD с лекарствами.
    /// </summary>
    public class IMedicineRepository : IRepository<Medicine>
    {
        private readonly List<Medicine> _medicines;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с пустым списком лекарств.
        /// </summary>
        public IMedicineRepository()
        {
            _medicines = new List<Medicine>(); // Пустой список лекарств
        }

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с заданным списком лекарств.
        /// </summary>
        /// <param name="medicineList">Список лекарств для инициализации репозитория</param>
        public IMedicineRepository(List<Medicine> medicineList)
        {
            _medicines = medicineList; // Инициализация репозитория переданным списком
        }

        /// <summary>
        /// Получает все лекарства из репозитория.
        /// </summary>
        /// <returns>Перечень всех лекарств в репозитории</returns>
        public IEnumerable<Medicine> GetAll()
        {
            return _medicines;
        }

        /// <summary>
        /// Получает лекарство по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор лекарства</param>
        /// <returns>Найдена ли запись. Если найдена, возвращает лекарство, иначе null</returns>
        public Medicine? GetById(int id)
        {
            return _medicines.FirstOrDefault(m => m.MedicineId == id);
        }

        /// <summary>
        /// Добавляет новое лекарство в репозиторий.
        /// </summary>
        /// <param name="medicine">Новое лекарство для добавления в репозиторий</param>
        /// <returns>Возвращает ID нового лекарства</returns>
        public int Post(Medicine medicine)
        {
            var newId = _medicines.Count > 0 ? _medicines.Max(m => m.MedicineId) + 1 : 1;
            medicine.MedicineId = newId;
            _medicines.Add(medicine); // Добавляем новое лекарство в список
            return newId;
        }

        /// <summary>
        /// Обновляет информацию о существующем лекарстве в репозитории.
        /// </summary>
        /// <param name="medicine">Лекарство с обновленными данными</param>
        /// <returns>Возвращает true, если лекарство было успешно обновлено, иначе false</returns>
        public bool Put(Medicine medicine)
        {
            var existingMedicine = GetById(medicine.MedicineId);
            if (existingMedicine == null)
                return false;

            existingMedicine.Name = medicine.Name;
            existingMedicine.ProductGroup = medicine.ProductGroup;
            existingMedicine.Quantity = medicine.Quantity;
            return true;
        }

        /// <summary>
        /// Удаляет лекарство из репозитория по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор лекарства для удаления</param>
        /// <returns>Возвращает true, если лекарство было успешно удалено, иначе false</returns>
        public bool Delete(int id)
        {
            var medicine = GetById(id);
            if (medicine == null)
                return false;

            _medicines.Remove(medicine); // Удаляем лекарство из списка
            return true;
        }
    }
}
