namespace AnalysisProgram.Models.Services
{
    public class StatsCalculator
    {
        //metoda licząca KDA na podstawie podanych przez użytkownika statystyk. Wynik zaokrląglony do 2 miejsc po przecinku
        public double KDACalculator(Stats model)
        {
            if (model.Kills == 0)
            {
                return (model.Kills + model.Assists);
            }
            else
            {
                double kda =(model.Kills + model.Assists) / (double)model.Deads;
                return Math.Round(kda, 2);
            }
        }

        //metoda licząca KDRatio
        public double KDRatioCalculator(Stats model)
        {
            if (model.Deads == 0)
            {
                return model.Kills;
            }
            else
            {
                double kdRatio = (double)model.Kills / model.Deads;
                return Math.Round(kdRatio, 2);
            }
        }

        //Metoda licząca procent trafionych headshotów
        public string HeadshotPercentageCalculator(Rifler model)
        {
            if (model.Headshots.HasValue && model.Kills > 0)
            {
                double headshotPercentage = ((double)model.Headshots.Value / model.Kills) * 100;
                return Math.Round(headshotPercentage, 2).ToString();
            }
            else if (!model.Headshots.HasValue)
            {
                return "Brak danych";
            }
            else
            {
                return "0";
            }
        }

        //Metoda licząca procent Entry Fragów
        public string EntryFragsPercentageCalculator(Rifler model)
        {
            if (model.EntryFrags.HasValue && model.Kills > 0)
            {
                double headshotPercentage = ((double)model.EntryFrags.Value / model.Kills) * 100;
                return Math.Round(headshotPercentage, 2).ToString();
            }
            else if (!model.EntryFrags.HasValue)
            {
                return "Brak danych";
            }
            else
            {
                return "0";
            }
        }

        //Metoda licząca procent zabójstw snajperką
        public string SniperWeaponKillsCalculator(Sniper model)
        {
            if (model.SniperWeaponKills.HasValue && model.Kills > 0)
            {
                double snipierWeaponKillsPercentage = ((double)model.SniperWeaponKills.Value / model.Kills) * 100;
                return Math.Round(snipierWeaponKillsPercentage, 2).ToString();
            }
            else if (!model.SniperWeaponKills.HasValue)
            {
                return "Brak danych";
            }
            else
            {
                return "0";
            }
        }

        //Metoda licząca procent zabójstw bez celownika
        public string NoScopeKillsCalculator(Sniper model)
        {
            if (model.NoScopeKills.HasValue && model.Kills > 0)
            {
                double noScopeKillsPercentage = ((double)model.NoScopeKills.Value / model.Kills) * 100;
                return Math.Round(noScopeKillsPercentage, 2).ToString();
            }
            else if (!model.NoScopeKills.HasValue)
            {
                return "Brak danych";
            }
            else
            {
                return "0";
            }
        }

    }
}
