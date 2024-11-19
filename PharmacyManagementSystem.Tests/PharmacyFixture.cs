using System;
using System.Collections.Generic;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Tests
{
    /// <summary>
    /// Класс для фикстуры данных аптек для использования в тестах.
    /// </summary>
    public class PharmacyFixture
    {
        public PharmacyRepository Repository { get; private set; }

        public PharmacyFixture()
        {
            Repository = new PharmacyRepository();

            
            var pharmacy1 = new Pharmacy
            {
                PharmacyId = 1,
                Name = "Аптека Здоровье",
                PhoneNumber = "+7 123 456 7890",
                Address = "ул. Ленина, 15",
                DirectorFullName = "Иванов Иван Иванович",
                PriceLists = new List<PriceList>
                {
                    new PriceList
                    {
                        PriceListId = 1,
                        Medicine = new Medicine
                        {
                            MedicineId = 1,
                            Name = "Аспирин",
                            ProductGroup = ProductGroupType.Painkillers,
                            PharmaceuticalGroups = new List<PharmaceuticalGroupType> { PharmaceuticalGroupType.GroupA },
                            Quantity = 100
                        },
                        Manufacturer = "ФармацевтПлюс",
                        PaymentConditions = PaymentConditionsType.Cash,
                        Supplier = "Завод1",
                        Price = 15.50m,
                        SaleDate = DateTime.Now,
                        Pharmacy = null
                    }
                }
            };

            
            var pharmacy2 = new Pharmacy
            {
                PharmacyId = 2,
                Name = "Аптека Надежда",
                PhoneNumber = "+7 987 654 3210",
                Address = "ул. Пушкина, 10",
                DirectorFullName = "Сидоров Сидор Сидорович",
                PriceLists = new List<PriceList>
                {
                    new PriceList
                    {
                        PriceListId = 2,
                        Medicine = new Medicine
                        {
                            MedicineId = 1,
                            Name = "Аспирин",
                            ProductGroup = ProductGroupType.Painkillers,
                            PharmaceuticalGroups = new List<PharmaceuticalGroupType> { PharmaceuticalGroupType.GroupA },
                            Quantity = 50
                        },
                        Manufacturer = "ФармацевтПлюс",
                        PaymentConditions = PaymentConditionsType.Cash,
                        Supplier = "Завод2",
                        Price = 14.50m,
                        SaleDate = DateTime.Now.AddDays(-5),
                        Pharmacy = null
                    }
                }
            };

            
            var pharmacy3 = new Pharmacy
            {
                PharmacyId = 3,
                Name = "Аптека Лекарь",
                PhoneNumber = "+7 111 222 3333",
                Address = "ул. Гагарина, 5",
                DirectorFullName = "Петров Петр Петрович",
                PriceLists = new List<PriceList>
                {
                    new PriceList
                    {
                        PriceListId = 3,
                        Medicine = new Medicine
                        {
                            MedicineId = 1,
                            Name = "Аспирин",
                            ProductGroup = ProductGroupType.Painkillers,
                            PharmaceuticalGroups = new List<PharmaceuticalGroupType> { PharmaceuticalGroupType.GroupA },
                            Quantity = 200
                        },
                        Manufacturer = "ФармацевтПлюс",
                        PaymentConditions = PaymentConditionsType.NonCash,
                        Supplier = "Завод3",
                        Price = 16.00m,
                        SaleDate = DateTime.Now.AddDays(-10),
                        Pharmacy = null
                    }
                }
            };

            Repository.AddPharmacy(pharmacy1);
            Repository.AddPharmacy(pharmacy2);
            Repository.AddPharmacy(pharmacy3);
        }
    }
}
