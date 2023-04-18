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
        readonly Entities _entities = new Entities(new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options); // use DB

        private readonly BookingService bookingService;

        public FlightAplicationSpecifications()
        {
           bookingService = new BookingService(entities: _entities);
        }

        [Theory]
        [InlineData("i@gmail.com", 2)]
        [InlineData("i@gmail.com", 2)]
        // public void Given_a_flight_When_I_book_the_flight_Then_the_flight_should_contain_my_booking(string passengerEmail, int numberOfSeats) //Based on GTW
        public void Remembers_bookings(string passengerEmail, int numberOfSeats)
        {

            var flight = new Flight(3);

            _entities.Flights.Add(flight);

            bookingService.Book(new BookDto(flightId: flight.Id, passengerEmail, numberOfSeats));

            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(passengerEmail, numberOfSeats));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        public void Frees_up_seats_after_booking(int initialCapacity)
        {
            // Given
            var flight = new Flight(initialCapacity);
            _entities.Flights.Add(flight); 

            bookingService.Book(new BookDto(flightId: flight.Id, passengerEmail: "i@gmail.com", numberOfSeats: 2));
            // When
            bookingService.CancelBooking(
                
                new CancelBookingDto(flightId :flight.Id,
                passengerEmail: "i@gmail.com",
                    numberOfSeats: 2)
                
                );
            // Then
            bookingService.GetRemainingNumberOfSeatsFor(flight.Id).Should().Be(initialCapacity);
        }
    }
};