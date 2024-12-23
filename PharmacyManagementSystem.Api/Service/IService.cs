using System.Collections.Generic;
using PharmacyManagementSystem.Api.Dto;


namespace PharmacyManagementSystem.Api.Service;
    /// <summary>
    /// Интерфейс для сервиса, предоставляющего операции CRUD.
    /// </summary>
    public interface IService<TGetDto, TPostDto>
    {
        /// <summary>
        /// Получить все сущности.
        /// </summary>
        IEnumerable<TGetDto> GetAll();

        /// <summary>
        /// Получить сущность по идентификатору.
        /// </summary>
        TGetDto? GetById(int id);

        /// <summary>
        /// Создать новую сущность.
        /// </summary>
        int Post(TPostDto postDto);

        /// <summary>
        /// Обновить существующую сущность.
        /// </summary>
        TGetDto? Put(int id, TPostDto putDto);

        /// <summary>
        /// Удалить сущность.
        /// </summary>
        bool Delete(int id);
    }

