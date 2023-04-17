﻿using Aplication;
using Data;

namespace Aplication
{
    public class BookingService
    {

        public Entities Entities { get; set; }
        public BookingService(Entities entities)
        {
            Entities = entities;
        }

        public void Book(BookDto bookDto)
        {
            var flight = Entities.Flights.Find(bookDto.FlightId);
            flight.Book(bookDto.PassengerEmail, bookDto.NumberOfSeats);
            Entities.SaveChanges();
        }

        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            return Entities.Flights.Find(flightId).BookingList.Select(booking => new BookingRm(booking.Email, booking.NumberOfSeats));
        }
    }

}