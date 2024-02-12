using Microsoft.AspNetCore.Mvc;
using FileManagementApplication.Interfaces;
using FileManagementApplication.Models.DTOs;

namespace FileManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] FlightDTO flightDTO)
        {
            if (_flightService.Add(flightDTO))
            {
                return Ok("Flight added successfully");
            }
            return BadRequest("Failed to add flight");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveFlight(string id)
        {
            if (_flightService.Remove(id))
            {
                return Ok($"Flight with ID {id} removed successfully");
            }
            return NotFound($"Flight with ID {id} not found");
        }

        [HttpPut]
        public IActionResult UpdateFlight([FromBody] FlightDTO flightDTO)
        {
            var updatedFlight = _flightService.Update(flightDTO);

            if (updatedFlight != null)
            {
                return Ok(updatedFlight);
            }
            return NotFound($"Flight with ID {flightDTO.FlightNumber} not found");
        }

        [HttpGet("{id}")]
        public IActionResult GetFlightById(string id)
        {
            var flight = _flightService.GetFlightkById(id);

            if (flight != null)
            {
                return Ok(flight);
            }
            return NotFound($"Flight with ID {id} not found");
        }

        [HttpGet]
        public IActionResult GetFlights()
        {
            var flights = _flightService.GetFlights();

            if (flights != null)
            {
                return Ok(flights);
            }
            return NotFound("No flights found");
        }
    }
}
