using System;
using System.Collections.Generic;

namespace Business.Dtos.Request.UserRequests
{
    public class CreateUserRequest
    {
        public Guid FacultyId { get; set; }
        public List<Guid> DepartmentIds { get; set; }
        public string SchoolNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
