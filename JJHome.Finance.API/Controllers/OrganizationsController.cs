using Microsoft.AspNetCore.Mvc;
using JJHome.Finance.API.Data;
using JJHome.Finance.Models;
using Microsoft.AspNetCore.Authorization;

namespace JJHome.Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationsController : FinanceControllerBase<Organization>
    {
        public OrganizationsController(ApplicationDbContext context) : base(context)
        {

        }        
    }
}
