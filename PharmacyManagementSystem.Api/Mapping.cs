using AutoMapper;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Enums;
using System.Collections.Generic;

namespace PharmacyManagementSystem.Api;
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Настройка маппинга для Pharmacy
            CreateMap<Pharmacy, PharmacyGetDto>();
            CreateMap<PharmacyPostDto, Pharmacy>();

            // Настройка маппинга для Medicine
            CreateMap<Medicine, MedicineGetDto>();
            CreateMap<MedicinePostDto, Medicine>();

            // Настройка маппинга для PriceList
            CreateMap<PriceList, PriceListGetDto>()
                .ForMember(dest => dest.PaymentConditions, opt => opt.MapFrom(src => src.PaymentConditions.ToString())); // Преобразуем PaymentConditionsType в строку
            CreateMap<PriceListPostDto, PriceList>();

            // Настройка маппинга для PharmaceuticalGroupType
            CreateMap<PharmaceuticalGroupType, PharmaceuticalGroupTypeDto>()
                .ConvertUsing(p => new PharmaceuticalGroupTypeDto { Value = p.ToString() });

            // Настройка маппинга для ProductGroupType
            CreateMap<ProductGroupType, ProductGroupTypeDto>()
                .ConvertUsing(p => new ProductGroupTypeDto { Value = p.ToString() });

            // Настройка маппинга для PaymentConditionsType
            CreateMap<PaymentConditionsType, PaymentConditionsTypeDto>()
                .ConvertUsing(p => new PaymentConditionsTypeDto { Value = p.ToString() });
        }
    }
