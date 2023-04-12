using Xunit;
using System;
using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class FlighSpecification
    {
        [Fact]
        public void Booking_reduces_the_number_of_seats()
        {
            var flight = new Flight(seatCapacity: 3);

            flight.Book("stefan.borcia@outlook.com", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);
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
    }
}