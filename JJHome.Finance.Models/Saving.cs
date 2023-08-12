namespace JJHome.Finance.Models
{
    public class Saving : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal AmountPerMonth { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
    }
}
