using Xunit;
using System;
using System.Net.NetworkInformation;
using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class FlighSpecification
    {
        [Theory]
        [InlineData(3,1,2)]  // Remove duplicate Code
        [InlineData(6,3,3)]
        [InlineData(8,3,5)]
        [InlineData(10,6,4)]
        public void Booking_reduces_the_number_of_seats1(int seatCapacity, int numberOfSeats, int remainingNumberOfSeats)
        {
            var flight = new Flight(seatCapacity: seatCapacity);

            flight.Book("stefan.borcia@outlook.com", numberOfSeats);

            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }

        [Fact]

        public void Avoids_overbooking()
        {
            // Given
            var flight = new Flight(seatCapacity: 3);

            // When
            var error = flight.Book("stefan.borcia@gmail.com", 4);

            // Then
            error.Should().BeOfType<OverbookingError>();
        }

        [Fact]

        public void Books_flights_successfully()
        {
            var flight = new Flight(seatCapacity: 3);
            var error = flight.Book("stefan.borcia@outlook.com", 1);
            error.Should().BeNull();
        }
    }
}