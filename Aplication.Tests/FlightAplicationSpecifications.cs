using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace Aplication.Tests
{
    public class FlightAplicationSpecifications
    {
        [Fact]
        public void Books_flights()
        {
           var bookingService = new BookingService();
           bookingService.Book(new BookDto());
           bookingService.FindBookings().Should().ContainEquivalentOf(new BookingRm());
        }
    }

    public class BookingService
    {
        public void Book(BookDto bookDto)
        {

        }

        public IEnumerable<BookingRm> FindBookings()
        {
            throw  new NotImplementedException();
        }
    }

    public class BookDto
    {

    }

    public class BookingRm
    {

    }
}