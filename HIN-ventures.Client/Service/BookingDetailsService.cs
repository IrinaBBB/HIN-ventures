using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Client.Service.IService;
using HIN_ventures.Models;
using Newtonsoft.Json;

namespace HIN_ventures.Client.Service
{
    public class BookingDetailsService : IBookingDetailsService
    {
        private readonly HttpClient _client;

        public BookingDetailsService(HttpClient client)
        {
            _client = client;
        }
        //public async Task<RoomOrderDetailsDTO> MarkPaymentSuccessful(RoomOrderDetailsDTO details)
        //{
        //    var content = JsonConvert.SerializeObject(details);
        //    var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        //    var response = await _client.PostAsync("api/roomorder/paymentsuccessful", bodyContent);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var contentTemp = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<RoomOrderDetailsDTO>(contentTemp);
        //        return result;
        //    }
        //    else
        //    {
        //        var contentTemp = await response.Content.ReadAsStringAsync();
        //        var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
        //        throw new Exception(errorModel.ErrorMessage);
        //    }
        //}

        public async Task<BookingDetailsDto> SaveBookingDetails(BookingDetailsDto details)
        {
            var content = JsonConvert.SerializeObject(details);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/assignmentorder/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BookingDetailsDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
