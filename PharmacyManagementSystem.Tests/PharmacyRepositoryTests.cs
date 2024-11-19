using System;
using System.Collections.Generic;
using Xunit;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Tests
{
    /// <summary>
    /// Класс тестов для PharmacyRepository
    /// </summary>
    public class PharmacyRepositoryTests
    {
        private readonly PharmacyRepository _repository;

        /// <summary>
        /// Инициализация тестов
        /// </summary>
        public PharmacyRepositoryTests()
        {
            _repository = new PharmacyRepository();
            
            // Аптека 1
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

            // Аптека 2
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

            // Аптека 3
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

            _repository.AddPharmacy(pharmacy1);
            _repository.AddPharmacy(pharmacy2);
            _repository.AddPharmacy(pharmacy3);
        }

        [Fact]
        public void Test_AddPharmacy_ShouldAddPharmacy()
        {
            // Arrange
            var pharmacy = new Pharmacy
            {
                PharmacyId = 4,
                Name = "Аптека Здоровье 2",
                PhoneNumber = "+7 123 456 7891",
                Address = "ул. Пушкина, 10",
                DirectorFullName = "Петров Петр Петрович",
                PriceLists = new List<PriceList>() // Добавление пустого списка PriceLists
            };

            // Act
            _repository.AddPharmacy(pharmacy);

            // Assert
            var pharmacies = _repository.GetAllPharmacies();
            Assert.Contains(pharmacies, p => p.PharmacyId == 4);
        }

        [Fact]
        public void Test_GetAllMedicinesInPharmacy_ShouldReturnMedicinesInPharmacy()
        {
            // Act
            var medicines = _repository.GetAllMedicinesInPharmacy(1);

            // Assert
            Assert.NotEmpty(medicines);
            Assert.Equal("Аспирин", medicines[0].Name);
        }

        [Fact]
        public void Test_GetPharmaciesWithMedicineInfo_ShouldReturnPharmaciesWithMedicine()
        {
            // Act
            var pharmacies = _repository.GetPharmaciesWithMedicineInfo("Аспирин");

            // Assert
            Assert.NotEmpty(pharmacies);
            Assert.Equal(1, pharmacies[0].Pharmacy.PharmacyId);
            Assert.Equal(100, pharmacies[0].Quantity);
        }

        [Fact]
        public void Test_GetAveragePriceByPharmaceuticalGroup_ShouldReturnCorrectAveragePrice()
        {
            // Act
            var result = _repository.GetAveragePriceByPharmaceuticalGroup();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(PharmaceuticalGroupType.GroupA.ToString(), result[0].PharmaceuticalGroup);
            Assert.Equal(15.50m, result[0].AveragePrice);
        }

        [Fact]
        public void Test_GetTop5PharmaciesBySales_ShouldReturnTopPharmacies()
        {
            // Act
            var topPharmacies = _repository.GetTop5PharmaciesBySales("Аспирин", DateTime.Now.AddMonths(-1), DateTime.Now);

            // Assert
            Assert.NotEmpty(topPharmacies);
            Assert.Equal(3, topPharmacies.Count); // Должно вернуть 3 аптеки
            Assert.Equal(3, topPharmacies[0].Pharmacy.PharmacyId); // Аптека с наибольшим количеством продаж - Аптека Лекарь
        }

        [Fact]
        public void Test_GetPharmaciesByRegionAndQuantity_ShouldReturnCorrectPharmacies()
        {
            // Act
            var pharmacies = _repository.GetPharmaciesByRegionAndQuantity("Ленина", "Аспирин", 50);

            // Assert
            Assert.NotEmpty(pharmacies);
            Assert.Equal(1, pharmacies[0].PharmacyId);
        }

        [Fact]
        public void Test_GetPharmaciesWithMinimumPrice_ShouldReturnPharmaciesWithMinimumPrice()
        {
            // Act
            var pharmacies = _repository.GetPharmaciesWithMinimumPrice("Аспирин");

            // Assert
            Assert.NotEmpty(pharmacies);
            Assert.Equal(2, pharmacies[0].PharmacyId); // Аптека Надежда с минимальной ценой 14.50
        }
    }
}
