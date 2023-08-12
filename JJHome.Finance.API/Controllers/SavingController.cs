using JJHome.Finance.API.Data;
using JJHome.Finance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JJHome.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SavingController : FinanceControllerBase<Saving>
    {
        public SavingController(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
