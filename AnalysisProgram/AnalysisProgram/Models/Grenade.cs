namespace AnalysisProgram.Models
{
    public class Grenade : CsGoItem
    {
        //Konstruktor
        public Grenade(string name, double price, int quantity, string type, double avgDmg, double duration, string dmgType) : base(name, price, quantity, type)
        {
            AvgDmg = avgDmg;
            Duration = duration;
            DmgType = dmgType;
        }

        //Właściowści
        public double AvgDmg { get; private set; }
        public double Duration { get; private set; }
        public string DmgType { get; private set; }

        //Implementacja metody abstrakcyjnej z klasy bazowej do wyliczenia całkowitej ceny przedmiotu
        public override double CalculateTotalPrice()
        {
            return Price * Quantity;
        }
        //Implementacja metody abstrakcyjnej z klasy bazowej do przekonwertowania ceny na napis w celu dodania innego tekstu
        public override string ConvertPriceToString()
        {
            return $"Całkowity koszt zakupu {Name} wyniósł: {CalculateTotalPrice()}. Granat zadaje obrażenia {DmgType}, " +
                $"czas trwania wybuchu wynosi: {Duration}.";
        }
    }
}