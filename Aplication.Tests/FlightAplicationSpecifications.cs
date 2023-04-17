using Xunit;
using System.Collections.Generic;
using Data;
using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Aplication;
using Microsoft.Graph.Beta.Models;

namespace Aplication.Tests
{
    public class FlightAplicationSpecifications
    {
        [Theory]
        [InlineData("i@s.com",3)]
        [InlineData("ids@s.com",1)]
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {

            var entities = new Entities(new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options);

            var flight = new Flight(3);

            var bookingService = new BookingService(entities: entities);
            entities.Flights.Add(flight);

            bookingService.Book(new BookDto(flightId: flight.Id, passengerEmail, numberOfSeats));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail, numberOfSeats));
        }
    }
}