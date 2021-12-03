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
                //var newOrder = _mapper.Map<BookingDetailsDto, BookingDetails>(details);

                var newAssignment = _mapper.Map<AssignmentDto, Assignment>(details.AssignmentDto);
                var newFreelancer = _mapper.Map<FreelancerDto, Freelancer>(details.FreelancerDto);
                
                
                BookingDetails newOrder = new()
                {
                    OrderStatus = SD.Status_Pending, //status will change once the assignment is picked up by the freelancer
                    UserId = details.UserId,
                    Name = details.Name,
                    Email = details.Email,
                    Phone = details.Phone,
                    Assignment = newAssignment,
                    Freelancer = newFreelancer
                };

                

                if(details.FreelancerDto != null)
                {
                    newAssignment.Freelancer = newOrder.Freelancer;
                    newOrder.OrderStatus = SD.Status_Booked;
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

        public async Task<IEnumerable<BookingDetailsDto>> GetAllBookingDetails()
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

        public async Task<BookingDetailsDto> GetBookingDetail(int orderId)
        {
            try
            {
                BookingDetails bookingOrder = await _db.BookingDetails
                    .Include(f => f.Freelancer) //.ThenInclude(x => x.HotelRoomImages) //må legge inn bilder av frilanser....se video 158
                    .FirstOrDefaultAsync(u => u.Id == orderId);

                BookingDetailsDto bookingDetailsDto = _mapper.Map<BookingDetails, BookingDetailsDto>(bookingOrder);

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
