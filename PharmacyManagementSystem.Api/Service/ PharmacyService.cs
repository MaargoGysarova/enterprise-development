using AutoMapper;
using System.Collections.Generic;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Repositories;

namespace PharmacyManagementSystem.Api.Service
{
    /// <summary>
    /// Сервис для работы с аптеками.
    /// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с аптеками.
    /// Позволяет получать информацию о всех аптеках, а также добавлять, обновлять и удалять аптеки по их идентификаторам.
    /// </summary>
    public class PharmacyService : IService<PharmacyGetDto, PharmacyPostDto>
    {
        private readonly IRepository<Pharmacy> _pharmacyRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса аптек.
        /// </summary>
        public PharmacyService(IRepository<Pharmacy> pharmacyRepository, IMapper mapper)
        {
            _pharmacyRepository = pharmacyRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает все аптеки из репозитория и преобразует их в DTO.
        /// </summary>
        public IEnumerable<PharmacyGetDto> GetAll()
        {
            var pharmacies = _pharmacyRepository.GetAll();
            return _mapper.Map<IEnumerable<PharmacyGetDto>>(pharmacies);
        }

        /// <summary>
        /// Получает аптеку по указанному идентификатору и преобразует её в DTO.
        /// </summary>
        public PharmacyGetDto? GetById(int id)
        {
            var pharmacy = _pharmacyRepository.GetById(id);
            return _mapper.Map<PharmacyGetDto>(pharmacy);
        }

        /// <summary>
        /// Добавляет новую аптеку, преобразуя данные из DTO в сущность.
        /// </summary>
        public int Post(PharmacyPostDto postDto)
        {
            var pharmacy = _mapper.Map<Pharmacy>(postDto);
            return _pharmacyRepository.Post(pharmacy);
        }

        /// <summary>
        /// Обновляет существующую аптеку по указанному идентификатору, используя данные из DTO.
        /// </summary>
        public PharmacyGetDto? Put(int id, PharmacyPostDto putDto)
        {
            var pharmacy = _pharmacyRepository.GetById(id);
            if (pharmacy == null)
            {
                return null;
            }

            var updatedPharmacy = _mapper.Map(putDto, pharmacy);
            _pharmacyRepository.Put(updatedPharmacy);
            return _mapper.Map<PharmacyGetDto>(updatedPharmacy);
        }

        /// <summary>
        /// Удаляет аптеку по указанному идентификатору.
        /// </summary>
        public bool Delete(int id)
        {
            return _pharmacyRepository.Delete(id);
        }
    }
}
