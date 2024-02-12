using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileManagementApplication.Models
{
    public class Flight
    {
        [Key]
        public string FlightNumber { get; set; }
        public string AirlineName { get; set; }
        public string DepartureCity { get;set; }
        public string ArrivalCity { get;set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public float Price { get; set; }
        public string Username { get; set; }
        [ForeignKey("Username")]
        public User? User { get; set; }

    }
}
