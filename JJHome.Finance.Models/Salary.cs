namespace JJHome.Finance.Models
{
    public class Salary : BaseModel
    {
        public decimal AmountPerMonth { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
