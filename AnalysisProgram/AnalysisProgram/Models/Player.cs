namespace AnalysisProgram.Models
{
    public class Player : Stats
    {
        
        //Konstruktor
        public Player(string name, string surname, string nick, int age, int price, int kills, int assists, int deads) : base (kills, assists, deads)
        {
            Name = name;
            Surname = surname;
            Nick = nick;
            Age = age;
            Price = price;
            
        }
        //Właściowści
        public string Name { get ; private set ; }
        public string Surname { get ; private set ; }
        public string Nick { get; private set; }
        public int Age { get; private set; }
        public int Price { get; private set; }
    }
}
