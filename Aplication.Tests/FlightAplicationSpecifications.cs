using Xunit;
using System.Collections.Generic;
using Data;
using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Tests
{
    public class FlightAplicationSpecifications
    {
        [Fact]
        public void Books_flights()
        {

            var entities = new Entities(new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options);

            var flight = new Flight(3);

            var bookingService = new BookingService(entities: entities);
            entities.Flights.Add(flight);

            bookingService.Book(new BookDto(
                flightId: flight.Id,
                passengerEmail: "s@gmail.com",
                numberOfSeats: 2
                ));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail: "s@gmail.com", numberOfSeats: 2));
        }
    }

    public class BookingService
    {
        public BookingService(Entities entities)
        {
        }

        public void Book(BookDto bookDto)
        {

        }

        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            return new[]
            {
                new BookingRm(passengerEmail: "s@gmail.com", numberOfSeats: 2)
            };
        }
    }

    public class BookDto
    {
        public BookDto(Guid flightId, string passengerEmail, int numberOfSeats)
        {

        }
    }

    public class BookingRm
    {
        public int NumberOfSeats { get; set; }
        public string PassengerEmail { get; set; }
        public BookingRm(string passengerEmail, int numberOfSeats)
        {
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }
}