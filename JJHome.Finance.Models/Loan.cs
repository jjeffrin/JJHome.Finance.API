namespace JJHome.Finance.Models
{
    public class Loan : BaseEffectiveDatedModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal AmountPerMonth { get; set; }
    }
}
