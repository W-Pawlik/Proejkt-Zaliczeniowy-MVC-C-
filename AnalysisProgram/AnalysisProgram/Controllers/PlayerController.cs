using AnalysisProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisProgram.Controllers
{
    public class PlayerController : Controller
    {
        //Wyświetlanie widoku Player
        public IActionResult Player()
        {
            return View();
        }

        //Przetwarzanie danych przesłanych z widoku Player
        [HttpPost]
        public IActionResult Player(PlayerViewModel[] models)
        {
            if (ModelState.IsValid)
            {

                Player[] player = new Player[models.Length];
                //Tworzenie obiektów Player na podstawie danych wprowadzonych przez użytkownika
                for (int i = 0; i < models.Length; i++)
                {
                    player[i] = new Player(
                        models[i].Name,
                        models[i].Surname,
                        models[i].Nick,
                        models[i].Age,
                        models[i].Price,
                        models[i].Kills,
                        models[i].Assists,
                        models[i].Deads
                    );
                }
                string aggressivePlayer;
                string supportPlayer;
                string betterKDAPriceRatio;

                // Porównywanie liczby zabójstw graczy i wybór najbardziej agresywnego gracza
                if (player[0].Kills > player[1].Kills)
                {
                    aggressivePlayer = player[0].Nick;
                }
                else if (player[0].Kills < player[1].Kills)
                {
                    aggressivePlayer = player[1].Nick;
                }
                else
                {
                    aggressivePlayer = "Obydowje graczy grają tak samo agresywnie";
                }

                //Porównywanie liczby asyst graczy i wybór gracza z większą liczbą asyst
                if (player[0].Assists > player[1].Assists)
                {
                    supportPlayer = player[0].Nick;
                }
                else if (player[0].Assists < player[1].Assists)
                {
                    supportPlayer = player[1].Nick;
                }
                else
                {
                    supportPlayer = "Obywdowje graczy posiada taką samą liczbę asyst";
                }

                //Obliczanie stosunku KDA do ceny dla obu graczy i wybór gracza z lepszym wynikiem
                double kdaPriceRatioPlayer1 = CalculateKdaPriceRatio(player[0]);
                double kdaPriceRatioPlayer2 = CalculateKdaPriceRatio(player[1]);

                if (kdaPriceRatioPlayer1 > kdaPriceRatioPlayer2)
                {
                    betterKDAPriceRatio = player[0].Nick;
                }
                else if (kdaPriceRatioPlayer1 < kdaPriceRatioPlayer2)
                {
                    betterKDAPriceRatio = player[1].Nick;
                }
                else
                {
                    betterKDAPriceRatio = "Both players have the same KDA-to-price ratio";
                }

                ViewBag.AggressivePlayer = aggressivePlayer;
                ViewBag.SupportPlayer = supportPlayer;
                ViewBag.BetterKDAPriceRatio = betterKDAPriceRatio;

                //Przekierowanie do widoku z rezultatem
                return View("FiltredPlayers", player);
            }

            return View(models);
        }

        //Obliczanie stosunku KDA do ceny dla danego gracza
        private static double CalculateKdaPriceRatio(Player player)
        {
            double kda = (player.Kills + player.Assists) / (double)player.Deads;
            return kda / player.Price;
        }

        //Wyświetlanie widoku FiltredPlayers z przefiltrowanymi graczami
        public IActionResult FiltredPlayers(Player[] player)
        {
            return View(player);
        }
    }
}
