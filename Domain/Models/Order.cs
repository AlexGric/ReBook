using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Order
    {
        public Order()
        {
            Books = new List<OrderDetail>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public ICollection<OrderDetail> Books { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }        
        public string PaymentStatus { get; set; }
    }
}