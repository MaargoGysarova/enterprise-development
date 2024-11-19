using System;
using System.Collections.Generic;
using System.Linq;
using PharmacyManagementSystem.Domain;

namespace PharmacyManagementSystem.Domain
{
    /// <summary>
    /// Класс, представляющий репозиторий аптек и предоставляющий методы для управления аптеками и препаратами.
    /// </summary>
    public class PharmacyRepository
    {
        /// <summary>
        /// Коллекция всех аптек, хранимая в виде словаря, где ключ - идентификатор аптеки.
        /// </summary>
        public Dictionary<int, Pharmacy> Pharmacies { get; set; } = new Dictionary<int, Pharmacy>();

        /// <summary>
        /// Добавить новую аптеку в репозиторий.
        /// </summary>
        /// <param name="pharmacy">Аптека для добавления.</param>
        public void AddPharmacy(Pharmacy pharmacy)
        {
            Pharmacies[pharmacy.PharmacyId] = pharmacy;
        }

        /// <summary>
        /// Получить список всех аптек из репозитория.
        /// </summary>
        /// <returns>Список всех аптек.</returns>
        public List<Pharmacy> GetAllPharmacies()
        {
            return Pharmacies.Values.ToList();
        }

        /// <summary>
        /// Добавить препарат в аптеку через прайс-лист.
        /// </summary>
        /// <param name="pharmacyId">Идентификатор аптеки, в которую добавляется препарат.</param>
        /// <param name="priceList">Прайс-лист с информацией о препарате.</param>
        public void AddMedicineToPharmacy(int pharmacyId, PriceList priceList)
        {
            if (Pharmacies.TryGetValue(pharmacyId, out var pharmacy))
            {
                pharmacy.PriceLists.Add(priceList);
            }
        }

        /// <summary>
        /// Получить сведения о всех препаратах в указанной аптеке, отсортированных по названию.
        /// </summary>
        /// <param name="pharmacyId">Идентификатор аптеки.</param>
        /// <returns>Список препаратов, отсортированный по названию.</returns>
        public List<Medicine> GetAllMedicinesInPharmacy(int pharmacyId)
        {
            if (!Pharmacies.TryGetValue(pharmacyId, out var pharmacy))
            {
                Console.WriteLine($"Аптека с ID {pharmacyId} не найдена.");
                return new List<Medicine>();
            }
            return pharmacy.PriceLists.Select(pl => pl.Medicine).OrderBy(m => m.Name).ToList();
        }

        /// <summary>
        /// Получить подробный список всех аптек, в которых имеется указанный препарат, с указанием его количества.
        /// </summary>
        /// <param name="medicineName">Название препарата.</param>
        /// <returns>Список кортежей, содержащих аптеку и количество препарата в ней.</returns>
        public List<(Pharmacy Pharmacy, int Quantity)> GetPharmaciesWithMedicineInfo(string medicineName)
        {
            return Pharmacies.Values
                .Where(p => p.PriceLists.Any(pl => pl.Medicine.Name == medicineName))
                .Select(p => (p, p.PriceLists.Where(pl => pl.Medicine.Name == medicineName).Sum(pl => pl.Medicine.Quantity)))
                .ToList();
        }

        /// <summary>
        /// Получить информацию о средней стоимости препаратов каждой фармацевтической группы для каждой аптеки.
        /// </summary>
        /// <returns>Список кортежей, содержащих аптеку, фармацевтическую группу и среднюю стоимость препаратов в данной группе.</returns>
        public List<(Pharmacy Pharmacy, string PharmaceuticalGroup, decimal AveragePrice)> GetAveragePriceByPharmaceuticalGroup()
        {
            return Pharmacies.Values.SelectMany(pharmacy =>
                pharmacy.PriceLists
                    .SelectMany(pl => pl.Medicine.PharmaceuticalGroups, (pl, group) => new { Pharmacy = pharmacy, Group = group.ToString(), pl.Price }) // Преобразуем группу в строку
                    .GroupBy(x => new { x.Pharmacy, x.Group })
                    .Select(g => (g.Key.Pharmacy, g.Key.Group, AveragePrice: g.Average(x => x.Price)))
            ).ToList();
        }

        /// <summary>
        /// Получить топ-5 аптек по количеству и объему продаж указанного препарата за указанный период времени.
        /// </summary>
        /// <param name="medicineName">Название препарата.</param>
        /// <param name="startDate">Начальная дата периода.</param>
        /// <param name="endDate">Конечная дата периода.</param>
        /// <returns>Список кортежей, содержащих аптеку, количество проданных препаратов и общую сумму продаж.</returns>
        public List<(Pharmacy Pharmacy, int QuantitySold, decimal TotalSales)> GetTop5PharmaciesBySales(string medicineName, DateTime startDate, DateTime endDate)
        {
            return Pharmacies.Values
                .Select(ph => new
                {
                    Pharmacy = ph,
                    QuantitySold = ph.PriceLists.Where(pl => pl.Medicine.Name == medicineName && pl.SaleDate >= startDate && pl.SaleDate <= endDate).Sum(pl => pl.Medicine.Quantity),
                    TotalSales = ph.PriceLists.Where(pl => pl.Medicine.Name == medicineName && pl.SaleDate >= startDate && pl.SaleDate <= endDate).Sum(pl => pl.Price)
                })
                .OrderByDescending(x => x.QuantitySold)
                .Take(5)
                .Select(x => (x.Pharmacy, x.QuantitySold, x.TotalSales))
                .ToList();
        }

        /// <summary>
        /// Получить список аптек, расположенных в указанном районе, которые продали указанный препарат в объеме больше заданного.
        /// </summary>
        /// <param name="region">Район, в котором находятся аптеки.</param>
        /// <param name="medicineName">Название препарата.</param>
        /// <param name="minQuantity">Минимальный объем продажи.</param>
        /// <returns>Список аптек, соответствующих указанным критериям.</returns>
        public List<Pharmacy> GetPharmaciesByRegionAndQuantity(string region, string medicineName, int minQuantity)
        {
            return Pharmacies.Values
                .Where(p => p.Address.Contains(region) && p.PriceLists.Any(pl => pl.Medicine.Name == medicineName && pl.Medicine.Quantity > minQuantity))
                .ToList();
        }

        /// <summary>
        /// Получить список аптек, в которых указанный препарат продается по минимальной цене.
        /// </summary>
        /// <param name="medicineName">Название препарата.</param>
        /// <returns>Список аптек, продающих препарат по минимальной цене.</returns>
        public List<Pharmacy> GetPharmaciesWithMinimumPrice(string medicineName)
        {
            var minPrice = Pharmacies.Values
                .SelectMany(p => p.PriceLists)
                .Where(pl => pl.Medicine.Name == medicineName)
                .Min(pl => pl.Price);

            return Pharmacies.Values
                .Where(p => p.PriceLists.Any(pl => pl.Medicine.Name == medicineName && pl.Price == minPrice))
                .ToList();
        }
    }
}
