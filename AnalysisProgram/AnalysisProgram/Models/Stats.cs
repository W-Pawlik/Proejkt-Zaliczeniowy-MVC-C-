namespace AnalysisProgram.Models
{
    public class Stats
    {        
        //konstruktor bezparametrowy w celu utworzenia instacji klasy bez wartości początkowych
        public Stats() { }

        //konstruktor służący do inicjalizacji pól klasy Stats
        public Stats(int kills, int deads, int assists)
        {
            Kills = kills;
            Deads = deads;
            Assists = assists;
        }
        
        //Właściwości
        public int Kills { get; private set; }
        public int Deads { get; private set; }
        public int Assists { get; private set; }

        
        
    }
}
