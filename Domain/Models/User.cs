using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public string Nickname { get; set; }
        public override string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int Cash { get; set; }
        
    }
}
