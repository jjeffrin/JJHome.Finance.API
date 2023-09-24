using System.Collections.ObjectModel;

namespace JJHome.Finance.Models
{
    public class DashboardInfo
    {
        public decimal MonthlySalary { get; set; }
        public decimal UsableMonthlySalary { get; set; }
        public decimal RemainingMonthlySalary { get; set; }
        public ICollection<Salary> Salaries { get; set; } = new Collection<Salary>();
    }
}
