using AnalysisProgram.Models;
using AnalysisProgram.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnalysisProgram.Controllers
{
    public class ShoppingCalculatorController : Controller
    {
        //Akcja wyświetlająca formularz kalkulatora zakupów
        public IActionResult ShoppingCalculator()
        {
            return View();
        }

        //Akcja obsługująca przesłanie formularza kalkulatora zakupów
        [HttpPost]
        public IActionResult ShoppingCalculator(List<CsGoItemViewModel> model)
        {
            var items = new List<CsGoItem>();

            foreach (var itemModel in model)
            {
                if (itemModel.Type == "Weapon")
                {
                    //Tworzenie obiektu Weapon na podstawie danych z formularza
                    var item = new Weapon(
                        itemModel.Name,
                        itemModel.Price,
                        itemModel.Quantity,
                        itemModel.Type,
                        itemModel.Ammo,
                        itemModel.AvgDmgPerShot,
                        itemModel.RecoilPercentage,
                        itemModel.IsSilenced
                    );


                    //Obliczanie całkowitej ceny broni
                    var totalWeaponPrice = item.CalculateTotalPrice();
                    var totalWeaponPriceToString = item.ConvertPriceToString();

                    //Przypisanie całkowitej ceny broni do ViewBag
                    ViewBag.WeaponPrice = totalWeaponPrice;
                    ViewBag.WeaponPriceToString = totalWeaponPriceToString;

                    items.Add(item);
                }
                else if (itemModel.Type == "Grenade")
                {
                    // Tworzenie obiektu Grenade na podstawie danych z formularza
                    var item = new Grenade(
                        itemModel.Name,
                        itemModel.Price,
                        itemModel.Quantity,
                        itemModel.Type,
                        itemModel.AvgDmg,
                        itemModel.Duration,
                        itemModel.DmgType
                    );

                    var totalPrice = item.CalculateTotalPrice();
                    var totalPriceToString = item.ConvertPriceToString();

                    ViewBag.Price = totalPrice;
                    ViewBag.PriceToString = totalPriceToString;

                    items.Add(item);
                }

                //Obliczanie całkowitej ceny wszystkich przedmiotów
                double totalPriceOfAllItems = 0;
                for (int i = 0; i < items.Count; i++)
                {
                    totalPriceOfAllItems += items[i].CalculateTotalPrice();
                }
                ViewBag.TotalPriceOfItems = totalPriceOfAllItems;

            }

            //Przekierowanie do widoku z wynikami kalkulacji zakupów
            return View("CalculatedPurchase", items);
        }

        //Akcja wyświetlająca wyniki kalkulacji zakupów
        public IActionResult CalculatedPurchase(List<CsGoItem> items)
        {
            return View(items);
        }
    }
}