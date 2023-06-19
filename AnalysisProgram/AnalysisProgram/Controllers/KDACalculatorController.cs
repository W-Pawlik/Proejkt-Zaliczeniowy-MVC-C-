using AnalysisProgram.Models;
using AnalysisProgram.Models.Services;
using Microsoft.AspNetCore.Mvc;


namespace AnalysisProgram.Controllers
{
    public class KDACalculatorController : Controller
    {

        private readonly StatsCalculator _statsCalculator;


        //Konstruktor inicjalizujący obiekt StatsCalculator
        public KDACalculatorController()
        {
            _statsCalculator = new StatsCalculator();
            
        }
        
        //wyświetlanie widoku KDACalculator
        public IActionResult KDACalculator()
        {
            return View();
        }

        //Wyświetlanie widoku SniperStatsForm
        [HttpGet]
        public IActionResult SniperStatsCalculator()
        {
            return View("SniperStatsForm");
        }

        //Wyświetlanie widoku RiflerStatsForm
        [HttpGet]
        public IActionResult RiflerStatsCalculator()
        {
            return View("RiflerStatsForm");
        }

        //Akcja POST, przetwarzanie danych przesłanych z widoku SniperStatsForm
        [HttpPost]
        public IActionResult SniperStatsCalculator(SniperViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Tworzenie obiektu Sniper na podstawie danych z formularza
                var sniper = new Sniper(
                    model.Kills,
                    model.Deads,
                    model.Assists,
                    model.SniperWeaponKills,
                    model.NoScopeKills
                    );

                //Wyliczanie statystyk za pomocą obiektu StatsCalculator
                double kda = _statsCalculator.KDACalculator(sniper);
                double kdRatio = _statsCalculator.KDRatioCalculator(sniper);
                string sniperWeaponKills = _statsCalculator.SniperWeaponKillsCalculator(sniper);
                string noScopeKills = _statsCalculator.NoScopeKillsCalculator(sniper);

                //Przekazanie wyników statystyk do ViewBag i przekierowanie do widoku CalculatedSniperStats
                ViewBag.KDA = kda;
                ViewBag.KDRatio = kdRatio;
                ViewBag.SniperWeaponKills = sniperWeaponKills;
                ViewBag.NoScopeKills = noScopeKills;

                return View("CalculatedSniperStats");
            }
            //Zwrócenie widoku SniperStatsForm jeśli ModelState nie jest poprawny
            return View("SniperStatsForm");
        }

        //Akcja POST, przetwarzanie danych przesłanych z widoku RiflerStatsForm
        [HttpPost]
        public IActionResult RiflerStatsCalculator(RilferViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Tworzenie obiektu Rifler na podstawie danych z formularza
                var rifler = new Rifler(
                    model.Kills,
                    model.Deads,
                    model.Assists,
                    model.Headshots,
                    model.EntryFrags
                    );

                // Wyliczanie statystyk za pomocą obiektu StatsCalculator
                double kda = _statsCalculator.KDACalculator(rifler);
                double kdRatio = _statsCalculator.KDRatioCalculator(rifler);
                string headshots = _statsCalculator.HeadshotPercentageCalculator(rifler);
                string entryFrags = _statsCalculator.EntryFragsPercentageCalculator(rifler);

                //Przekazanie wyników statystyk do ViewBag i przekierowanie do widoku CalculatedRiflerStats
                ViewBag.KDA = kda;
                ViewBag.KDRatio = kdRatio;
                ViewBag.Headshots = headshots;
                ViewBag.EntryFrags = entryFrags;


                return View("CalculatedRiflerStats");
            }

            return View("RiflerStatsForm");
        }
    }
}
