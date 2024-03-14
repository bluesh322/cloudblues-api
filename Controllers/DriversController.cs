using cloudblues_api.Models;
using MapperApp.Models.DTOs.Incoming;
using Microsoft.AspNetCore.Mvc;

namespace cloudblues_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly pgContext _dbContext;
        private readonly ILogger<DriversController> _logger;
        private static List<Driver> drivers = new List<Driver>();

        public DriversController(pgContext dbContext, ILogger<DriversController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }        

        // GET all drivers
        [HttpGet]
        public IActionResult GetDriver()
        {
            var allDrivers = drivers.Where(x => x.Status == 1).ToList();
            return Ok(allDrivers);
        }

        [HttpGet("{id}")]
        public IActionResult GetDriver(Guid id)
        {
            var item = drivers.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateDriver(DriverCreateDto data)
        {
            if (ModelState.IsValid)
            {
                var _driver = new Driver()
                {
                    Id = Guid.NewGuid(),
                    Status = 1,
                    DateAdded = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    DriverNumber = data.DriverNumber,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    WorldChampionships = data.WorldChampionships,
                };

                drivers.Add(_driver);
                return CreatedAtAction("GetDriver", new { _driver.Id });
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutDriver(Guid id, Driver data)
        {
            if (id == data.Id)
            {
                return BadRequest();
            }

            var existingDriver = drivers.FirstOrDefault(x => x.Id == data.Id);

            if(existingDriver == null)
            {
                return NotFound();
            }

            existingDriver.DriverNumber = data.DriverNumber;
            existingDriver.FirstName = data.FirstName;
            existingDriver.LastName = data.LastName;
            existingDriver.WorldChampionships = data.WorldChampionships;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(Guid id)
        {
            var existingDriver = drivers.FirstOrDefault(x => x.Id == id);

            if(existingDriver == null)
            {
                return NotFound();
            }

            existingDriver.Status = 0;

            return NoContent();
        }
    }
}
