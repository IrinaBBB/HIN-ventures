﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Business.Repositories.IRepositories;
using HIN_ventures.Models;

namespace HIN_ventures_Api.Controllers
{
     [ApiController]
    [Route("api/[controller]/[action]")]
    public class AssignmentOrderController : Controller
    {
        private readonly IBookingDetailsRepository _repository;
        //private readonly IEmailSender _emailSender;

        public AssignmentOrderController(IBookingDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookingDetailsDto details)
        {
            if (ModelState.IsValid)
            {
                var result = await _repository.Create(details);
                return Ok(result);
            }
            else
            {
                return BadRequest(new ErrorModel()
                {
                    ErrorMessage = "Error while creating Room Details/ Booking"
                });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> PaymentSuccessful([FromBody] BookingDetailsDto details)
        //{

        //    var service = new SessionService();
        //    var sessionDetails = service.Get(details.StripeSessionId);
        //    if (sessionDetails.PaymentStatus == "paid")
        //    {
        //        var result = await _repository.MarkPaymentSuccessful(details.Id);
        //        if (result == null)
        //        {
        //            return BadRequest(new ErrorModel()
        //            {
        //                ErrorMessage = "Can not mark payment as successful"
        //            });
        //        }
        //        await _emailSender.SendEmailAsync(details.Email, "Booking Confirmed - Hidden Villa",
        //            "Your booking has been confirmed at Hidden Villa with order ID :" + details.Id);
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(new ErrorModel()
        //        {
        //            ErrorMessage = "Can not mark payment as successful"
        //        });
        //    }

        //}
    }
}
