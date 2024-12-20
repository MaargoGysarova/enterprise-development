using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Data;
using PharmacyManagementSystem.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyManagementSystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с аптечными данными.
    /// Реализует методы для выполнения операций CRUD с аптеками.
    /// </summary>
    public class IPharmacyRepository : IRepository<Pharmacy>
    {
        private readonly PharmacyDbContext _context;
        /// <summary>
        /// Инициализирует новый экземпляр репозитория с пустым списком аптек.
        /// </summary>
        public IPharmacyRepository(PharmacyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает все аптеки из репозитория.
        /// </summary>
        /// <returns>Перечень всех аптек в репозитории</returns>
        public IEnumerable<Pharmacy> GetAll()
        {
            return _context.Pharmacies.ToList();
        }

        /// <summary>
        /// Получает аптеку по заданному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор аптеки</param>
        /// <returns>Найдена ли аптека. Если найдена, возвращает аптеку, иначе null</returns>
        public Pharmacy? GetById(int id)
        {
            return _context.Pharmacies.Find(id);
        }

        /// <summary>
        /// Добавляет новую аптеку в репозиторий.
        /// </summary>
        /// <param name="pharmacy">Новая аптека для добавления в репозиторий</param>
        /// <returns>Возвращает ID новой аптеки</returns>
        public int Post(Pharmacy pharmacy)
        {
            _context.Pharmacies.Add(pharmacy);
            _context.SaveChanges();
            return pharmacy.PharmacyId;
        }

        /// <summary>
        /// Обновляет информацию об аптеке в репозитории.
        /// </summary>
        /// <param name="pharmacy">Аптека с обновленными данными</param>
        /// <returns>Возвращает true, если аптека была успешно обновлена, иначе false</returns>
        public bool Put(Pharmacy pharmacy)
        {
             var existingPharmacy = _context.Pharmacies.Find(pharmacy.PharmacyId);
            if (existingPharmacy == null)
                return false;

            // Обновляем значения
            existingPharmacy.Name = pharmacy.Name;
            existingPharmacy.Address = pharmacy.Address;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет аптеку из репозитория по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор аптеки для удаления</param>
        /// <returns>Возвращает true, если аптека была успешно удалена, иначе false</returns>
        public bool Delete(int id)
        {
            var pharmacy = _context.Pharmacies.Find(id);
            if (pharmacy == null)
                return false;

            _context.Pharmacies.Remove(pharmacy);
            _context.SaveChanges();
            return true;
        }
    }
}
