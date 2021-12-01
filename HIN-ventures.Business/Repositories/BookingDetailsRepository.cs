using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Common;
using HIN_ventures.DataAccess.Data;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;
using Microsoft.EntityFrameworkCore;

namespace HIN_ventures.Business.Repositories
{
    public class BookingDetailsRepository : IBookingDetailsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BookingDetailsRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<BookingDetailsDto> Create(BookingDetailsDto details)
        {
            try
            {
                var newOrder = _mapper.Map<BookingDetailsDto, BookingDetails>(details);
                newOrder.OrderStatus = SD.Status_Pending; //status will change once the assignment is picked up by the freelancer

                if(details.FreelancerDto.FreelancerId != 0)
                {
                    details.FreelancerId = details.FreelancerDto.FreelancerId;
                    details.FreelancerDto = await _db.Freelancers.FindAsync(details.FreelancerId);

                }

                
                var result = await _db.BookingDetails.AddAsync(newOrder);
                await _db.SaveChangesAsync();
                return _mapper.Map<BookingDetails, BookingDetailsDto>(result.Entity);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<BookingDetailsDto>> GetBookingDetails()
        {
            try
            {
                IEnumerable<BookingDetailsDto> customerOrder =
                    _mapper.Map<IEnumerable<BookingDetails>, IEnumerable<BookingDetailsDto>>
                        (_db.BookingDetails.Include(f => f.Freelancer).Include(a => a.Assignment));

                return customerOrder;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<BookingDetailsDto> GetFreelancerOrderDetail(int freelancerOrderId)
        {
            try
            {
                BookingDetails freelancerOrder = await _db.BookingDetails
                    .Include(f => f.Freelancer) //.ThenInclude(x => x.HotelRoomImages) //må legge inn bilder av frilanser her
                    .FirstOrDefaultAsync(u => u.Id == freelancerOrderId);

                BookingDetailsDto bookingDetailsDto = _mapper.Map<BookingDetails, BookingDetailsDto>(freelancerOrder);
                //roomOrderDetailsDTO.HotelRoomDTO.TotalDays = roomOrderDetailsDTO.CheckOutDate
                //    .Subtract(roomOrderDetailsDTO.CheckInDate).Days;

                return bookingDetailsDto;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<bool> UpdateOrderStatus(int orderId, string status)
        {
            throw new NotImplementedException();
        }



        //public async Task<BookingDetailsDto> MarkPaymentSuccessful(int id)
        //{
        //    var data = await _db.AssignmentOrderDetails.FindAsync(id);
        //    if (data == null)
        //    {
        //        return null;
        //    }
        //    if (!data.IsPaymentSuccessful)
        //    {
        //        data.IsPaymentSuccessful = true;
        //        data.OrderStatus = SD.Status_Booked;
        //        var markPaymentSuccessful = _db.AssignmentOrderDetails.Update(data);
        //        await _db.SaveChangesAsync();
        //        return _mapper.Map<AssignmentOrderDetails, BookingDetailsDto>(markPaymentSuccessful.Entity);
        //    }
        //    return new BookingDetailsDto();
        //}

        //public async Task<bool> UpdateOrderStatus(int RoomOrderId, string status)
        //{
        //    try
        //    {
        //        var roomOrder = await _db.AssignmentOrderDetails.FirstOrDefaultAsync(u => u.Id == RoomOrderId);
        //        if (roomOrder == null)
        //        {
        //            return false;
        //        }
        //        roomOrder.OrderStatus = status;
        //        if (status == SD.Status_Booked)
        //        {
        //            //roomOrder.ActualCheckInDate = DateTime.Now;
        //        }
        //        if (status == SD.Status_Assignment_Completed)
        //        {
        //            //roomOrder.ActualCheckOutDate = DateTime.Now;
        //        }
        //        await _db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}
    }
}
