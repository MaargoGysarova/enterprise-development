using System;
using System.Collections.Generic;
using Xunit;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Tests
{
    /// <summary>
    /// Класс тестов для PharmacyRepository с использованием фикстуры данных
    /// </summary>
    public class PharmacyRepositoryTests : IClassFixture<PharmacyFixture>
    {
        private readonly PharmacyRepository _repository;

        /// <summary>
        /// Инициализация тестов с использованием PharmacyFixture
        /// </summary>
        /// <param name="fixture">Фикстура с данными аптек</param>
        public PharmacyRepositoryTests(PharmacyFixture fixture)
        {
            _repository = fixture.Repository;
        }

        /// <summary>
        /// Тест для проверки добавления аптеки в репозиторий
        /// </summary>
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
                PriceLists = new List<PriceList>() 
            };

            // Act
            _repository.AddPharmacy(pharmacy);

            // Assert
            var pharmacies = _repository.GetAllPharmacies();
            Assert.Contains(pharmacies, p => p.PharmacyId == 4);
        }

        /// <summary>
        /// Тест для получения всех препаратов в аптеке по заданному идентификатору аптеки
        /// </summary>
        [Fact]
        public void Test_GetAllMedicinesInPharmacy_ShouldReturnMedicinesInPharmacy()
        {
            // Act
            var medicines = _repository.GetAllMedicinesInPharmacy(1);

            // Assert
            Assert.NotEmpty(medicines);
            Assert.Equal("Аспирин", medicines[0].Name);
        }

        /// <summary>
        /// Тест для получения всех аптек, содержащих указанный препарат, с информацией о количестве
        /// </summary>
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

        /// <summary>
        /// Тест для получения средней стоимости препаратов по фармацевтической группе в каждой аптеке
        /// </summary>
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

        /// <summary>
        /// Тест для получения топ-5 аптек по количеству и объему продаж заданного препарата за указанный период времени
        /// </summary>
        [Fact]
        public void Test_GetTop5PharmaciesBySales_ShouldReturnTopPharmacies()
        {
            // Act
            var topPharmacies = _repository.GetTop5PharmaciesBySales("Аспирин", DateTime.Now.AddMonths(-1), DateTime.Now);

            // Assert
            Assert.NotEmpty(topPharmacies);
            Assert.Equal(3, topPharmacies.Count);
            Assert.Equal(3, topPharmacies[0].Pharmacy.PharmacyId);
        }

        /// <summary>
        /// Тест для получения списка аптек в заданном регионе, которые продали больше определенного количества препарата
        /// </summary>
        [Fact]
        public void Test_GetPharmaciesByRegionAndQuantity_ShouldReturnCorrectPharmacies()
        {
            // Act
            var pharmacies = _repository.GetPharmaciesByRegionAndQuantity("Ленина", "Аспирин", 50);

            // Assert
            Assert.NotEmpty(pharmacies);
            Assert.Equal(1, pharmacies[0].PharmacyId);
        }

        /// <summary>
        /// Тест для получения списка аптек, продающих указанный препарат по минимальной цене
        /// </summary>
        [Fact]
        public void Test_GetPharmaciesWithMinimumPrice_ShouldReturnPharmaciesWithMinimumPrice()
        {
            // Act
            var pharmacies = _repository.GetPharmaciesWithMinimumPrice("Аспирин");

            // Assert
            Assert.NotEmpty(pharmacies);
            Assert.Equal(2, pharmacies[0].PharmacyId); 
        }
    }
}
