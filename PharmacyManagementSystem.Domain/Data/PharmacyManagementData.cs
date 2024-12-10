using System;
using System.Collections.Generic;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Enums;

namespace PharmacyManagementSystem.Domain
{
    /// <summary>
    /// Класс для инициализации данных для аптек, медикаментов и прайс-листов.
    /// </summary>
    public class PharmacyManagementData
    {
        public List<Pharmacy> Pharmacies { get; set; }
        public List<Medicine> Medicines { get; set; }
        public List<PriceList> PriceLists { get; set; }

        /// <summary>
        /// Конструктор для инициализации данных.
        /// </summary>
        public PharmacyManagementData()
        {
            // Создаем объекты медикаментов
            var medicine1 = new Medicine
            {
                MedicineId = 1,
                Name = "Аспирин",
                ProductGroup = ProductGroupType.Painkillers,
                Quantity = 100
            };

            var medicine2 = new Medicine
            {
                MedicineId = 2,
                Name = "Витамин C",
                ProductGroup = ProductGroupType.Vitamins,
                Quantity = 150
            };

            var medicine3 = new Medicine
            {
                MedicineId = 3,
                Name = "Парацетамол",
                ProductGroup = ProductGroupType.Painkillers,
                Quantity = 200
            };

            Medicines = new List<Medicine> { medicine1, medicine2, medicine3 };

            // Создаем объекты аптек
            var pharmacy1 = new Pharmacy
            {
                PharmacyId = 1,
                Name = "Аптека Здоровье",
                PhoneNumber = "+7 123 456 7890",
                Address = "ул. Ленина, 15",
                DirectorFullName = "Иванов Иван Иванович",
                PriceLists = new List<PriceList>()
            };

            var pharmacy2 = new Pharmacy
            {
                PharmacyId = 2,
                Name = "Аптека Надежда",
                PhoneNumber = "+7 987 654 3210",
                Address = "ул. Пушкина, 10",
                DirectorFullName = "Сидоров Сидор Сидорович",
                PriceLists = new List<PriceList>()
            };

            var pharmacy3 = new Pharmacy
            {
                PharmacyId = 3,
                Name = "Аптека Лекарь",
                PhoneNumber = "+7 111 222 3333",
                Address = "ул. Гагарина, 5",
                DirectorFullName = "Петров Петр Петрович",
                PriceLists = new List<PriceList>()
            };

            Pharmacies = new List<Pharmacy> { pharmacy1, pharmacy2, pharmacy3 };

            // Создаем прайс-листы и связываем их с аптеками и медикаментами
            var priceList1 = new PriceList
            {
                PriceListId = 1,
                Pharmacy = pharmacy1,
                Medicine = medicine1,
                Manufacturer = "ФармацевтПлюс",
                PaymentConditions = PaymentConditionsType.Cash,
                Supplier = "Завод1",
                Price = 15.50m,
                SaleDate = DateTime.Now
            };

            var priceList2 = new PriceList
            {
                PriceListId = 2,
                Pharmacy = pharmacy2,
                Medicine = medicine2,
                Manufacturer = "ФармацевтПлюс",
                PaymentConditions = PaymentConditionsType.NonCash,
                Supplier = "Завод2",
                Price = 25.00m,
                SaleDate = DateTime.Now.AddDays(-2)
            };

            var priceList3 = new PriceList
            {
                PriceListId = 3,
                Pharmacy = pharmacy3,
                Medicine = medicine3,
                Manufacturer = "Завод3",
                PaymentConditions = PaymentConditionsType.Cash,
                Supplier = "Завод3",
                Price = 12.00m,
                SaleDate = DateTime.Now.AddDays(-5)
            };

            PriceLists = new List<PriceList> { priceList1, priceList2, priceList3 };

            // Добавляем прайс-листы в соответствующие аптеки
            pharmacy1.PriceLists.Add(priceList1);
            pharmacy2.PriceLists.Add(priceList2);
            pharmacy3.PriceLists.Add(priceList3);
        }
    }
}
