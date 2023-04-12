using Xunit;
using System;
using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class FlighSpecification
    {
        [Fact]
        public void Booking_reduces_the_number_of_seats1()
        {
            var flight = new Flight(seatCapacity: 3);

            flight.Book("stefan.borcia@outlook.com", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);
        }
        [Fact]
        public void Booking_reduces_the_number_of_seats2()
        {
            var flight = new Flight(seatCapacity: 10);

            flight.Book("stefan.borcia@outlook.com", 6);

            flight.RemainingNumberOfSeats.Should().Be(4);
        }
        
        [Fact]
        public void Booking_reduces_the_number_of_seats3()
        {
            var flight = new Flight(seatCapacity: 6);

            flight.Book("stefan.borcia@outlook.com", 3);

            flight.RemainingNumberOfSeats.Should().Be(3);
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