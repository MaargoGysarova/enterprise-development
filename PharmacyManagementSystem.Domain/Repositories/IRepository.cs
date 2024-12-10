namespace PharmacyManagementSystem.Domain.Repositories
{
    /// <summary>
    /// Интерфейс для работы с основными CRUD-операциями для сущностей
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// Получить все элементы
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получить элемент по идентификатору
        /// </summary>
        T? GetById(int id);

        /// <summary>
        /// Добавить новый элемент
        /// </summary>
        int Post(T entity);

        /// <summary>
        /// Обновить существующий элемент
        /// </summary>
        bool Put(T entity);

        /// <summary>
        /// Удалить элемент по идентификатору
        /// </summary>
        bool Delete(int id);
    }
}
