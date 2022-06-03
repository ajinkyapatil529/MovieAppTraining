using System;
using System.Collections.Generic;
using System.Text;
using MovieApp.Entity;
using MovieApp.Data.Repositaries;
namespace MovieApp.Business.Services
{
    public class BookingService

    {
        IBooking _iBooking;

        public BookingService(IBooking booking)
        {
            _iBooking = booking;
        }
        public string BookingRegister(BookingModel bookingModel)
        {
            return _iBooking.BookingRegister(bookingModel);
        }

        public List<BookingModel> GetAllBookings()
        {
            return _iBooking.GetAllBookings();
        }
    }
}
