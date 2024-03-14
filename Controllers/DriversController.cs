using AutoMapper;
using cloudblues_api.Models;
using cloudblues_api.Models.DTOs.Incoming;
using cloudblues_api.Models.DTOs.Outgoing;
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
        private readonly IMapper _mapper;

        public DriversController(pgContext dbContext, ILogger<DriversController> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }        

        // GET all drivers
        [HttpGet]
        public IActionResult GetDriver()
        {
            var allDrivers = drivers.Where(x => x.Status == 1).ToList();

            var _drivers = _mapper.Map<IEnumerable<DriverDto>>(allDrivers);
            return Ok(_drivers);
        }

        [HttpPost]
        public IActionResult CreateDriver(DriverCreateDto data)
        {
            if (ModelState.IsValid)
            {
                var _driver = _mapper.Map<Driver>(data);

                drivers.Add(_driver);

                var newDriver = _mapper.Map<DriverDto>(_driver);
                return CreatedAtAction("GetDriver", new { _driver.Id }, newDriver);
            }

            return NoContent();
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
