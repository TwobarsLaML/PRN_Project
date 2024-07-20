using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer
{
    public class BookingDetailDAO
    {
        private FuminiHotelManagementContext db = new FuminiHotelManagementContext();
        public List<BookingDetail> GetAllBookingDetail()
        {
            List<BookingDetail> bookingDetails = new List<BookingDetail>();
            try
            {

                bookingDetails = db.BookingDetails
                    .Include(br => br.BookingReservation)
                    .ThenInclude(c => c.Customer)
                    .Include(r => r.Room).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot find booking details");
            }
            return bookingDetails;
        }

        public void AddBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                db.BookingDetails.Add(bookingDetail);
                db.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public void RemoveBookingDetail(BookingDetail bookingDetail)
        {
            try
            {
                db.BookingDetails.Remove(bookingDetail);
                db.SaveChanges();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}
