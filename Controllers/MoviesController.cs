using cloudblues_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cloudblues_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;

        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if(_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.Movies.ToListAsync();
        }

        //Get: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if(_dbContext == null)
            {
                return NotFound();
            }
            var movie = await _dbContext.Movies.FindAsync(id);
            
            if(movie == null)
            {
                return NotFound();
            }

            return movie;
        }
    }
}
