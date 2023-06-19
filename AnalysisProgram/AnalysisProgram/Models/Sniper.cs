namespace AnalysisProgram.Models
{
    public class Sniper : Stats
    {
        //konstruktor bezparametrowy w celu utworzenia instacji klasy bez wartości początkowych
        public Sniper() { }

        //konstruktor służący do inicjalizacji pól klasy Stats
        public Sniper(int kills, int deads, int assists, int sniperWeaponKills, int noScopeKills) : base(kills, deads, assists)
        {
            SniperWeaponKills = sniperWeaponKills;
            NoScopeKills = noScopeKills;
        }

        //Właściowści
        public int? SniperWeaponKills { get; private set; }
        public int? NoScopeKills { get; private set; }
    }
}
