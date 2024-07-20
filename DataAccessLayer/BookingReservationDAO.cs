using BusinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookingReservationDAO 
    {
        private FuminiHotelManagementContext db = new FuminiHotelManagementContext();

        public List<BookingReservation> GetAllReservations()
        {
            List<BookingReservation> list = new List<BookingReservation>();
            try
            {
                list = db.BookingReservations.ToList();
            }
            catch (Exception ex)
            {
            }
            return list;
        }
        public List<BookingReservation> GetBookingReservationByCustomerID(int id)
        {
            List<BookingReservation> list = new List<BookingReservation>();
            try
            {
                list = db.BookingReservations.Where(c => c.CustomerId == id).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;

        }

        public void AddReservation(BookingReservation reservation)
        {
            try
            {
                db.BookingReservations.Add(reservation);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void RemoveReservation(BookingReservation reservation)
        {
            try
            {
                db.BookingReservations.Remove(reservation);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        
    }
}
