using AutoMapper;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Repositories;
using System.Collections.Generic;

namespace PharmacyManagementSystem.Api.Service
{
    /// <summary>
    /// Сервис для работы с препаратами.
    /// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с препаратами.
    /// Позволяет получать информацию о всех препаратах, а также добавлять, обновлять и удалять препараты по их идентификаторам.
    /// </summary>
    public class MedicineService : IService<MedicineGetDto, MedicinePostDto>
    {
        private readonly IRepository<Medicine> _medicineRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса препаратов.
        /// </summary>
        public MedicineService(IRepository<Medicine> medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает все препараты из репозитория и преобразует их в DTO.
        /// </summary>
        public IEnumerable<MedicineGetDto> GetAll()
        {
            var medicines = _medicineRepository.GetAll();
            return _mapper.Map<IEnumerable<MedicineGetDto>>(medicines);
        }

        /// <summary>
        /// Получает препарат по указанному идентификатору и преобразует его в DTO.
        /// </summary>
        public MedicineGetDto? GetById(int id)
        {
            var medicine = _medicineRepository.GetById(id);
            return _mapper.Map<MedicineGetDto>(medicine);
        }

        /// <summary>
        /// Добавляет новый препарат, преобразуя данные из DTO в сущность.
        /// </summary>
        public int Post(MedicinePostDto postDto)
        {
            var medicine = _mapper.Map<Medicine>(postDto);
            return _medicineRepository.Post(medicine);
        }

        /// <summary>
        /// Обновляет существующий препарат по указанному идентификатору, используя данные из DTO.
        /// </summary>
        public MedicineGetDto? Put(int id, MedicinePostDto putDto)
        {
            var medicine = _medicineRepository.GetById(id);
            if (medicine == null)
            {
                return null;
            }

            var updatedMedicine = _mapper.Map(putDto, medicine);
            _medicineRepository.Put(updatedMedicine);
            return _mapper.Map<MedicineGetDto>(updatedMedicine);
        }

        /// <summary>
        /// Удаляет препарат по указанному идентификатору.
        /// </summary>
        public bool Delete(int id)
        {
            return _medicineRepository.Delete(id);
        }
    }
}
