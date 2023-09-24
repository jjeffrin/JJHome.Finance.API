namespace JJHome.Finance.Models
{
    public class Salary : BaseEffectiveDatedModel
    {
        public string? Description { get; set; }
        public decimal AmountPerMonth { get; set; }        
        public int OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
