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

        [Fact]
        public void Remembers_bookings()
        {
            var flight = new Flight(seatCapacity: 150);

            flight.Book(passengerEmail: "stefan@outlook.com", numberOfSeats: 4);

            flight.BookingList.Should().ContainEquivalentOf(new Booking("stefan@outlook.com", 4));
        }

        [Theory]
        [InlineData(3,1,1,3)]
        [InlineData(4,2,2,4)]
        [InlineData(7,5,4,6)]


        public void Canceling_bookings_frees_up_the_seats(
            int initialCapacity, 
            int numberOfSeatsToBook,
            int numberOfSeatsToCancel,
            int remainingNumberOfSeats
            )
        {
            // Given
            var flight = new Flight(initialCapacity);
            flight.Book(passengerEmail: "s@g.com", numberOfSeats: numberOfSeatsToBook);
            
            // When
            flight.CancelBooking(passengerEmail: "s@g.com", numberOfSeats: numberOfSeatsToCancel);

            // Then
            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }


        [Fact]
        public void Doesnt_cancel_bookings_for_passengers_who_have_not_booked()
        {
            var flight = new Flight(3);

            var error = flight.CancelBooking(passengerEmail: "s@g.com", numberOfSeats: 2);

            error.Should().BeOfType<BookingNotFoundError>();
        }

        [Fact]
        public void Returns_null_when_successfully_cancel_a_booking()
        {
            var flight = new Flight(3);
            flight.Book(passengerEmail: "s@g.com", numberOfSeats: 1);

            var error = flight.CancelBooking(passengerEmail: "s@g.com", numberOfSeats: 1);

            error.Should().BeNull();
        }
    }
}