using System;
using System.Collections.Generic;
using System.Linq;
using PharmacyManagementSystem;


namespace PharmacyManagementSystem
{
    public class PharmacyRepository
    {
        public Dictionary<int, Pharmacy> Pharmacies { get; set; } = new Dictionary<int, Pharmacy>();

        // Метод для добавления аптеки
        public void AddPharmacy(Pharmacy pharmacy)
        {
            Pharmacies[pharmacy.PharmacyId] = pharmacy;
        }

        // Метод для получения списка всех аптек
        public List<Pharmacy> GetAllPharmacies()
        {
            return Pharmacies.Values.ToList();
        }

        // Метод для добавления лекарства в аптеку через прайс-лист
        public void AddMedicineToPharmacy(int pharmacyId, PriceList priceList)
        {
            if (Pharmacies.TryGetValue(pharmacyId, out var pharmacy))
            {
                pharmacy.PriceLists.Add(priceList);
            }
        }

        // 1. Вывести сведения о всех препаратах в заданной аптеке, упорядочить по названию
        public List<Medicine> GetAllMedicinesInPharmacy(int pharmacyId)
        {
            if (!Pharmacies.TryGetValue(pharmacyId, out var pharmacy))
            {
                Console.WriteLine($"Аптека с ID {pharmacyId} не найдена.");
                return new List<Medicine>();
            }
            return pharmacy.PriceLists.Select(pl => pl.Medicine).OrderBy(m => m.Name).ToList();
        }

        // 2. Вывести для данного препарата подробный список всех аптек с указанием количества препарата в аптеках
        public List<(Pharmacy Pharmacy, int Quantity)> GetPharmaciesWithMedicineInfo(string medicineName)
        {
            return Pharmacies.Values
                .Where(p => p.PriceLists.Any(pl => pl.Medicine.Name == medicineName))
                .Select(p => (p, p.PriceLists.Where(pl => pl.Medicine.Name == medicineName).Sum(pl => pl.Medicine.Quantity)))
                .ToList();
        }

        // 3. Вывести информацию о средней стоимости препаратов каждой фармацевтической группе для каждой аптеки
       public List<(Pharmacy Pharmacy, string PharmaceuticalGroup, decimal AveragePrice)> GetAveragePriceByPharmaceuticalGroup()
{
    return Pharmacies.Values.SelectMany(pharmacy =>
        pharmacy.PriceLists
            .SelectMany(pl => pl.Medicine.PharmaceuticalGroups, (pl, group) => new { Pharmacy = pharmacy, Group = group.ToString(), pl.Price }) // Преобразуем группу в строку
            .GroupBy(x => new { x.Pharmacy, x.Group })
            .Select(g => (g.Key.Pharmacy, g.Key.Group, AveragePrice: g.Average(x => x.Price)))
    ).ToList();
}


        // 4. Вывести топ 5 аптек по количеству и объёму продаж данного препарата за указанный период времени
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

        // 5. Вывести список аптек указанного района, продавших заданный препарат более указанного объёма
        public List<Pharmacy> GetPharmaciesByRegionAndQuantity(string region, string medicineName, int minQuantity)
        {
            return Pharmacies.Values
                .Where(p => p.Address.Contains(region) && p.PriceLists.Any(pl => pl.Medicine.Name == medicineName && pl.Medicine.Quantity > minQuantity))
                .ToList();
        }

        // 6. Вывести список аптек, в которых указанный препарат продается с минимальной ценой
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
