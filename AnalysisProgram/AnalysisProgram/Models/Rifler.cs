namespace AnalysisProgram.Models
{
    public class Rifler : Stats
    {
       
        //konstruktor bezparametrowy w celu utworzenia instacji klasy bez wartości początkowych
        public Rifler() { }

        //konstruktor służący do inicjalizacji pól klasy Stats
        public Rifler(int kills, int deads, int assists, int headshots, int entryFrags) : base(kills, deads, assists)
        {
            Headshots = headshots;
            EntryFrags = entryFrags;
        }

        //Właściwości
        public int? Headshots { get; private set; }
        public int? EntryFrags { get; private set; }

    }

}

