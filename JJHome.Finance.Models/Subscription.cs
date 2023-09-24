namespace JJHome.Finance.Models
{
    public class Subscription : BaseEffectiveDatedModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal AmountPerMonth { get; set; }
    }
}
