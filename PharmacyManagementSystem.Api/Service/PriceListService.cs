using AutoMapper;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Repositories;
using System.Collections.Generic;



namespace PharmacyManagementSystem.Api.Service
{
    /// <summary>
    /// Сервис для работы с прайс-листами.
    /// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с прайс-листами.
    /// Позволяет получать информацию о всех прайс-листах, а также добавлять, обновлять и удалять прайс-листы по их идентификаторам.
    /// </summary>
    public class PriceListService : IService<PriceListGetDto, PriceListPostDto>
    {
        private readonly IRepository<PriceList> _priceListRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса прайс-листов.
        /// </summary>
        public PriceListService(IRepository<PriceList> priceListRepository, IMapper mapper)
        {
            _priceListRepository = priceListRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает все прайс-листы из репозитория и преобразует их в DTO.
        /// </summary>
        public IEnumerable<PriceListGetDto> GetAll()
        {
            var priceLists = _priceListRepository.GetAll();
            return _mapper.Map<IEnumerable<PriceListGetDto>>(priceLists);
        }

        /// <summary>
        /// Получает прайс-лист по указанному идентификатору и преобразует его в DTO.
        /// </summary>
        public PriceListGetDto? GetById(int id)
        {
            var priceList = _priceListRepository.GetById(id);
            return _mapper.Map<PriceListGetDto>(priceList);
        }

        /// <summary>
        /// Добавляет новый прайс-лист, преобразуя данные из DTO в сущность.
        /// </summary>
        public int Post(PriceListPostDto postDto)
        {
            var priceList = _mapper.Map<PriceList>(postDto);
            return _priceListRepository.Post(priceList);
        }

        /// <summary>
        /// Обновляет существующий прайс-лист по указанному идентификатору, используя данные из DTO.
        /// </summary>
        public PriceListGetDto? Put(int id, PriceListPostDto putDto)
        {
            var priceList = _priceListRepository.GetById(id);
            if (priceList == null)
            {
                return null;
            }

            var updatedPriceList = _mapper.Map(putDto, priceList);
            _priceListRepository.Put(updatedPriceList);
            return _mapper.Map<PriceListGetDto>(updatedPriceList);
        }

        /// <summary>
        /// Удаляет прайс-лист по указанному идентификатору.
        /// </summary>
        public bool Delete(int id)
        {
            return _priceListRepository.Delete(id);
        }
    }
}
