using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Text { get; set; }
        
    }
}
