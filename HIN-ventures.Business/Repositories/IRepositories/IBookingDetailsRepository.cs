﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories.IRepositories
{
    public interface IBookingDetailsRepository
    {
        public Task<BookingDetailsDto> Create(BookingDetailsDto details);
        public Task<BookingDetailsDto> GetFreelancerOrderDetail(int orderId);
        public Task<IEnumerable<BookingDetailsDto>> GetBookingDetails();
        public Task<bool> UpdateOrderStatus(int orderId, string status);

    }
}
