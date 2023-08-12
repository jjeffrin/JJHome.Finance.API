namespace JJHome.Finance.Models
{
    public class Loan : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public decimal AmountPerMonth { get; set; }
    }
}
