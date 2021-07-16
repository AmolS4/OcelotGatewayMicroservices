using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace ProductService.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
    }


    public class RegistationDb:List<Registration>
    {
        public RegistationDb()
        {
            Add(new Registration() { Id = 1, Email = "amol@gmail.com", Password = "Admin.123"});
            Add(new Registration() { Id = 2, Email = "ganesh@test.com", Password = "Admin@123" });
            Add(new Registration() { Id = 3, Email = "sachin@test.com", Password = "sachin@456"});
          

        }

    }
}
