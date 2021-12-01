using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIN_ventures.Common
{
    public static class SD
    {
        public const string RoleAdmin = "Admin";
        public const string Role_Customer = "Customer";
        public const string Role_Freelancer = "Freelancer";

        //public const string Local_InitialBooking = "InitialAssignmentBookingInfo";

        public const string HinCryptoAddress = "2N1spDd7mDaBfHbCRKGq9p28BwBo2XjmrEF"; // Dogecoin (TESTNET!) address
        public const string ApiKey = "9da8-f106-e0c7-e733"; //API key for dogecoin on BlockIO testnet
        public const string Pin = "H5sbN8Ra34KjgaTFEBcN"; //Accessing BlockIO

        public const string Local_OrderDetails = "AssignmentOrderDetails";
        public const string Local_Token = "JWT Token";
        public const string LocalUserDetails = "User Details"; //logged in user
        public const string FreelancerDetails = "User Details"; //logged in user
        public const string CustomerDetails = "User Details"; //logged in user


        public const string Status_Pending = "Pending";
        public const string Status_Booked = "Booked";
        public const string Status_Assignment_Completed = "CheckedOut";
    }
}
