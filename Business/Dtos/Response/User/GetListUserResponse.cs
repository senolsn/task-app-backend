using System;
using System.Collections.Generic;

namespace Business.Dtos.Response.UserResponses
{
    public class GetListUserResponse
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
