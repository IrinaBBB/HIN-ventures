using System;
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
        public Task<BookingDetailsDto> GetRoomOrderDetail(int roomOrderId);
        public Task<IEnumerable<BookingDetailsDto>> GetAllRoomOrderDetails();
        public Task<bool> UpdateOrderStatus(int OrderId, string status);

    }
}
