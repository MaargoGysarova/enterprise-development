using PharmacyManagementSystem.Domain.Data;

namespace PharmacyManagementSystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными о лекарствах.
    /// Реализует методы для выполнения операций CRUD с лекарствами.
    /// </summary>
    public class IMedicineRepository : IRepository<Medicine>
    {
        private readonly PharmacyDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория с контекстом базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public IMedicineRepository(PharmacyDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Получает все лекарства из репозитория.
        /// </summary>
        /// <returns>Перечень всех лекарств в репозитории</returns>
        public IEnumerable<Medicine> GetAll()
        {
            return _context.Medicines.ToList();
        }

        /// <summary>
        /// Получает лекарство по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор лекарства</param>
        /// <returns>Найдена ли запись. Если найдена, возвращает лекарство, иначе null</returns>
        public Medicine? GetById(int id)
        {
            return _context.Medicines.Find(id);
        }

        /// <summary>
        /// Добавляет новое лекарство в репозиторий.
        /// </summary>
        /// <param name="medicine">Новое лекарство для добавления в репозиторий</param>
        /// <returns>Возвращает ID нового лекарства</returns>
        public int Post(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
            return medicine.MedicineId; 
        }

        /// <summary>
        /// Обновляет информацию о существующем лекарстве в репозитории.
        /// </summary>
        /// <param name="medicine">Лекарство с обновленными данными</param>
        /// <returns>Возвращает true, если лекарство было успешно обновлено, иначе false</returns>
        public bool Put(Medicine medicine)
        {
            var existingMedicine = _context.Medicines.Find(medicine.MedicineId);
            if (existingMedicine == null)
                return false;

            // Обновляем значения
            existingMedicine.Name = medicine.Name;
            existingMedicine.ProductGroup = medicine.ProductGroup;
            existingMedicine.Quantity = medicine.Quantity;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет лекарство из репозитория по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор лекарства для удаления</param>
        /// <returns>Возвращает true, если лекарство было успешно удалено, иначе false</returns>
        public bool Delete(int id)
        {
            var medicine = _context.Medicines.Find(id);
            if (medicine == null)
                return false;

            _context.Medicines.Remove(medicine);
            _context.SaveChanges();
            return true;
        }
    }
}
