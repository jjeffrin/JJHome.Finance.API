using JJHome.Finance.Models;

namespace JJHome.Finance.API.Data
{
    public static class Extensions
    {
        public static IQueryable<T> WhereForUserAndSalaryMonth<T>(this IQueryable<T> source, string email, DateTime salaryMonthStart) where T : BaseEffectiveDatedModel
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(email);
            ArgumentNullException.ThrowIfNull(salaryMonthStart);

            var salaryMonthEnd = salaryMonthStart.AddMonths(1).AddDays(-1);

            return source.Where(x => x.UserId == email && x.EffectiveFrom <= salaryMonthStart && x.EffectiveTo >= salaryMonthStart && x.EffectiveFrom <= salaryMonthEnd && x.EffectiveTo >= salaryMonthEnd);
        }
    }
}
