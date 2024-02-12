using FileManagementApplication.Contexts;
using FileManagementApplication.Interfaces;
using FileManagementApplication.Models;

namespace FileManagementApplication.Repositories
{
    public class FlightRepository: IRepository<string, Flight>
    {
        private readonly FlightContext _context;
        public FlightRepository(FlightContext context)
        {
            _context = context;
        }
        public Flight Add(Flight entity)
        {
            _context.Flights.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Flight Delete(string key)
        {
            var flight = GetById(key);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
                return flight;
            }
            return null;
        }

        public IList<Flight> GetAll()
        {
            if (_context.Flights.Count() == 0)
                return null;
            return _context.Flights.ToList();
        }

        public Flight GetById(string Key)
        {
            var flights = _context.Flights.SingleOrDefault(u => u.FlightNumber == Key);
            return flights;
        }

        public Flight Update(Flight flighta)
        {
            _context.Flights.Update(flighta);
            _context.SaveChanges();
            return flighta;
        }
    }
}
