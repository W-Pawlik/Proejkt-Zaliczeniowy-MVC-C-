namespace AnalysisProgram.Models
{
    public abstract class CsGoItem
    {
        //Konstruktor klasy bazowej CsGoItem, inicjalizuje właściwości obiektu
        public CsGoItem(string name, double price, int quantity, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }

        //Właściowści z prywatnymi setterami(enkapsulacja)
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public string Type { get; protected set; }


        //Metoda abstrakcyjna, która jest zaimplementowana w klasach pochodnych, służąca do obliczenia całkowitej ceny przedmiotu
        public abstract double CalculateTotalPrice();

        //Metoda abstrakcyjna, która konwertuje cenę przedmiotu na stringa w celu wyświetlenia dodatkowych informacji
        public abstract string ConvertPriceToString();
    }
}