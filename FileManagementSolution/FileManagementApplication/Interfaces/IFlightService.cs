using FileManagementApplication.Models.DTOs;

namespace FileManagementApplication.Interfaces
{
    public interface IFlightService
    {
        bool Add(FlightDTO flightDTO);
        bool Remove(string id);
        FlightDTO Update(FlightDTO flightDTO);
        FlightDTO GetFlightkById(string id);
        IEnumerable<FlightDTO> GetFlights();
    }
}
