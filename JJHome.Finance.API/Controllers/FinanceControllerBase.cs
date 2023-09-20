using JJHome.Finance.API.Data;
using JJHome.Finance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JJHome.Finance.API.Controllers
{
    public class FinanceControllerBase<T> : ControllerBase where T : BaseModel
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApplicationDbContext _context;

        public FinanceControllerBase(ApplicationDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _context = dbContext;
        }

        // GET: api/Organizations
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            if (_dbSet == null)
            {
                return NotFound();
            }
            return await _dbSet.ToListAsync();
        }

        // GET: api/user@mail.com
        [HttpGet("GetByUserId/{userId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetByUserId(string userId)
        {
            if (_dbSet == null)
            {
                return NotFound();
            }

            IQueryable<T> entityUserIdQuery = _dbSet.Where(x => x.UserId.Equals(userId));
            return await entityUserIdQuery.ToListAsync();
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<T>> Get(int id)
        {
            if (_dbSet == null)
            {
                return NotFound();
            }
            var organization = await _dbSet.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // PUT: api/Organizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Put(int id, T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Organizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<T>> Post(T entity)
        {
            if (_dbSet == null)
            {
                return Problem($"Entity set 'ApplicationDbContext.{nameof(entity)}'  is null.");
            }
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (_dbSet == null)
            {
                return NotFound();
            }
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return (_dbSet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
