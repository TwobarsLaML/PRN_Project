using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookingReservationRepository
    {
        private static BookingReservationDAO bookingReservationDAO = new BookingReservationDAO();


        public static List<BookingReservation> GetAllReservations() {  return bookingReservationDAO.GetAllReservations();}
        public static List<BookingReservation> GetBookingReservationsByCustomerID(int id)
        {
            return bookingReservationDAO.GetBookingReservationByCustomerID(id);
        }

        public static void AddBookingReservation(BookingReservation bookingReservation)
        {
            bookingReservationDAO.AddReservation(bookingReservation);
        }

        public static void RemoveBR(BookingReservation bookingReservation)
        {
            bookingReservationDAO.RemoveReservation(bookingReservation);
        }

    }
}
