namespace AnalysisProgram.Models
{
    public class CsGoItemViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public int Ammo { get; set; }
        public double AvgDmgPerShot { get; set; }
        public double RecoilPercentage { get; set; }
        public bool IsSilenced { get; set; }
        public double AvgDmg { get; set; }
        public double Duration { get; set; }
        public string DmgType { get; set; }

    }
}