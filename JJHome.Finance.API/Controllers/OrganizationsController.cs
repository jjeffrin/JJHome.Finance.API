using Microsoft.AspNetCore.Mvc;
using JJHome.Finance.API.Data;
using JJHome.Finance.Models;

namespace JJHome.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : FinanceControllerBase<Organization>
    {
        public OrganizationsController(ApplicationDbContext context) : base(context)
        {

        }        
    }
}
