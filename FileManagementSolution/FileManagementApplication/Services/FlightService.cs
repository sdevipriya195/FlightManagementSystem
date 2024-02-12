using System.Collections.Generic;
using FileManagementApplication.Interfaces;
using FileManagementApplication.Models;
using FileManagementApplication.Models.DTOs;
using FileManagementApplication.Repositories;

namespace FileManagementApplication.Services
{
    public class FlightService : IFlightService
    {
        private readonly FlightRepository _flightRepository;

        public FlightService(FlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public bool Add(FlightDTO flightDTO)
        {
            var flight = new Flight
            {
                FlightNumber = flightDTO.FlightNumber,
                AirlineName = flightDTO.AirlineName,
                DepartureCity = flightDTO.DepartureCity,
                ArrivalCity = flightDTO.ArrivalCity,
                DepartureDateTime = flightDTO.DepartureDateTime,
                ArrivalDateTime = flightDTO.ArrivalDateTime,
                Price = flightDTO.Price,
                Username = flightDTO.Username
            };

            _flightRepository.Add(flight);
            return true; // You might want to handle errors and return false if the addition fails
        }

        public bool Remove(string id)
        {
            var removedFlight = _flightRepository.Delete(id);
            return removedFlight != null;
        }

        public FlightDTO Update(FlightDTO flightDTO)
        {
            var existingFlight = _flightRepository.GetById(flightDTO.FlightNumber);

            if (existingFlight != null)
            {
                // Update the properties of the existing flight with the DTO values
                existingFlight.AirlineName = flightDTO.AirlineName;
                existingFlight.DepartureCity = flightDTO.DepartureCity;
                existingFlight.ArrivalCity = flightDTO.ArrivalCity;
                existingFlight.DepartureDateTime = flightDTO.DepartureDateTime;
                existingFlight.ArrivalDateTime = flightDTO.ArrivalDateTime;
                existingFlight.Price = flightDTO.Price;
                existingFlight.Username = flightDTO.Username;

                _flightRepository.Update(existingFlight);
                return flightDTO; // Return the input DTO since no mapping is required
            }

            return null; // Handle the case where the flight with the given ID is not found
        }

        public FlightDTO GetFlightkById(string id)
        {
            var flight = _flightRepository.GetById(id);
            return flight != null ? new FlightDTO
            {
                FlightNumber = flight.FlightNumber,
                AirlineName = flight.AirlineName,
                DepartureCity = flight.DepartureCity,
                ArrivalCity = flight.ArrivalCity,
                DepartureDateTime = flight.DepartureDateTime,
                ArrivalDateTime = flight.ArrivalDateTime,
                Price = flight.Price,
                Username = flight.Username
            } : null;
        }

        public IEnumerable<FlightDTO> GetFlights()
        {
            var flights = _flightRepository.GetAll();
            if (flights != null)
            {
                List<FlightDTO> flightDTOs = new List<FlightDTO>();
                foreach (var flight in flights)
                {
                    flightDTOs.Add(new FlightDTO
                    {
                        FlightNumber = flight.FlightNumber,
                        AirlineName = flight.AirlineName,
                        DepartureCity = flight.DepartureCity,
                        ArrivalCity = flight.ArrivalCity,
                        DepartureDateTime = flight.DepartureDateTime,
                        ArrivalDateTime = flight.ArrivalDateTime,
                        Price = flight.Price,
                        Username = flight.Username
                    });
                }
                return flightDTOs;
            }
            return null;
        }
    }
}
