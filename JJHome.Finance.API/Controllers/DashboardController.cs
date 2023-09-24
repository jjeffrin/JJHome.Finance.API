using JJHome.Finance.API.Data;
using JJHome.Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JJHome.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/Dashboard
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<DashboardInfo>> Get(string email, DateTime salaryMonth)
        {
            /* ASSUMPTIONS:
             * 1. salaryMonth parameter sent in will always have its date as 1
             */

            // check if context is init
            if (_context == null) return NotFound("DB Context is not initialized.");

            // get salary entries for current user & salary month
            var salaries = await _context.Salaries.WhereForUserAndSalaryMonth(email, salaryMonth).ToListAsync();

            // run query & fetch salary records
            //var salaries = await salaryQueryWithFilter.ToListAsync();

            // proceed if there is at least 1 salary entry for the current user & salary month
            if (!salaries.IsNullOrEmpty())
            {
                // just total the AmountPerMonth, as there can be multiple income source for the current user
                var totalSalaryForMonth = salaries.Sum(x => x.AmountPerMonth);

                // create DashboardInfo instance & set the calculated total salary for current month
                var dashInfo = new DashboardInfo()
                {
                    MonthlySalary = totalSalaryForMonth,
                    Salaries = salaries
                };

                // calculate & set usableMonthlySalary
                var usableMonthlySalary = await GetUsableMonthlySalary(email, totalSalaryForMonth, salaryMonth);
                dashInfo.UsableMonthlySalary = usableMonthlySalary;

                // calculate & set remainingMonthlySalary
                var remainingMonthlySalary = await GetRemainingMonthlySalary(email, usableMonthlySalary, salaryMonth);
                dashInfo.RemainingMonthlySalary = remainingMonthlySalary;

                // return Ok with dashInfo
                return Ok(dashInfo);
            }
            else
            {
                return NotFound("No salary entry found for user");
            }            
        }

        /// <summary>
        /// Totals Loans, Savings and Subscription costs and then subtracts it from the monthly salary
        /// </summary>
        /// <returns></returns>
        private async Task<decimal> GetUsableMonthlySalary(string email, decimal monthlySalary, DateTime effFrom)
        {
            decimal loanTotal = 0;
            decimal savingsTotal = 0;
            decimal subsTotal = 0;

            var loans = await _context.Loans.WhereForUserAndSalaryMonth(email, effFrom).ToListAsync();
            var savings = await _context.Savings.WhereForUserAndSalaryMonth(email, effFrom).ToListAsync();
            var subs = await _context.Subscriptions.WhereForUserAndSalaryMonth(email, effFrom).ToListAsync();

            if (loans.Count > 0)
            {
                loanTotal = loans.Sum(x => x.AmountPerMonth);
            }

            if (savings.Count > 0)
            {
                savingsTotal = savings.Sum(x => x.AmountPerMonth);
            }

            if (subs.Count > 0)
            {
                subsTotal = subs.Sum(x => x.AmountPerMonth);
            }

            decimal remainingMonthlySalary = monthlySalary - (loanTotal + savingsTotal + subsTotal);
            return remainingMonthlySalary;
        }

        private async Task<decimal> GetRemainingMonthlySalary(string email, decimal usableMonthlySalary, DateTime effFrom)
        {
            decimal expensesTotal = 0;

            // calculate the last date of the salary month
            var effTo = effFrom.AddMonths(1).AddDays(-1);

            var expenses = await _context.Expenses.Where(x => x.UserId == email && effFrom <= x.CreatedAt && effTo >= x.CreatedAt).ToListAsync();

            if (expenses.Count > 0)
            {
                expensesTotal = expenses.Sum(x => x.Amount);
            }

            decimal remainingMonthlySalary = usableMonthlySalary - expensesTotal;
            return remainingMonthlySalary;
        }
    }
}
