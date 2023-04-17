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
        readonly Entities entities = new Entities(new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options); // use DB

        private readonly BookingService bookingService;

        public FlightAplicationSpecifications()
        {
           bookingService = new BookingService(entities: entities);
        }

        [Theory]
        [InlineData("i@s.com",3)]
        [InlineData("ids@s.com",1)]
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {

            var flight = new Flight(3);

            entities.Flights.Add(flight);

            bookingService.Book(new BookDto(flightId: flight.Id, passengerEmail, numberOfSeats));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail, numberOfSeats));
        }

        [Fact]

        public void Cancels_booking()
        {
            // Given
            var flight = new Flight(3);
            entities.Flights.Add(flight);

            bookingService.Book(new BookDto(flightId: flight.Id, passengerEmail: "i@gmail.com", numberOfSeats: 2));
            // When
            bookingService.CancelBooking(
                
                new CancelBookingDto(flightId :Guid.NewGuid(),
                passengerEmail: "i@gmail.com",
                    numberOfSeats: 2)
                
                );
            // Then
            bookingService.GetRemainingNumberOfSeatsFor(flight.Id).Should().Be(3);
        }
    }
};