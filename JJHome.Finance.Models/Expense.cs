namespace JJHome.Finance.Models
{
    public class Expense : BaseModel
    {
        public int ExpenseTypeId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public ExpenseType? ExpenseType { get; set; }
    }
}
