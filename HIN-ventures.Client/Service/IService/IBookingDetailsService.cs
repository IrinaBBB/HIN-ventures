using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Client.Service.IService
{
    public interface IBookingDetailsService
    {
        public Task<BookingDetailsDto> SaveBookingDetails(BookingDetailsDto details);
        //public Task<BookingDetailsDto> MarkPaymentSuccessful(BookingDetailsDto details);

    }
}
