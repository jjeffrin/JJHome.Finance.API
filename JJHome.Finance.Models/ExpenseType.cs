namespace JJHome.Finance.Models
{
    public class ExpenseType : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
    }
}
