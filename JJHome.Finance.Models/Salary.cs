namespace JJHome.Finance.Models
{
    public class Salary : BaseModel
    {
        public string? Description { get; set; }
        public decimal AmountPerMonth { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
