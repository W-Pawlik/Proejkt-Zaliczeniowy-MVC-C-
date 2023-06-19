namespace AnalysisProgram.Models
{
    public class Weapon : CsGoItem
    {
        //Konstruktor
        public Weapon(string name, double price, int quantity, string type, int ammo, double avgDmgPerShot, double recoilPercentage, bool isSilenced) : base(name, price, quantity, type)
        {
            Ammo = ammo;
            AvgDmgPerShot = avgDmgPerShot;
            RecoilPercentage = recoilPercentage;
            IsSilenced = isSilenced;
        }

        //Właściowści
        public int Ammo { get; private set; }
        public double AvgDmgPerShot { get; private set; }
        public double RecoilPercentage { get; private set; }
        public bool IsSilenced { get; private set; }


        //Implementacja metody abstrakcyjnej, obliczającej całkowity koszt zakupu broni
        public override double CalculateTotalPrice()
        {
            return Price * Quantity;
        }

        //Implementacja metody abstrakcyjnej, konwertującej koszt zakupu broni na string
        public override string ConvertPriceToString()
        {
            return $"Całkowity koszt zakupu {Name} wyniósł: {CalculateTotalPrice()}. Broń ta posiada {Ammo} amunicji, " +
                $"jej średnie obrażenia wynoszą: {AvgDmgPerShot} a procent odrzutu: {RecoilPercentage}";
        }
    }
}