namespace JJHome.Finance.Models
{
    public class BaseEffectiveDatedModel : BaseModel
    {
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
    }
}
