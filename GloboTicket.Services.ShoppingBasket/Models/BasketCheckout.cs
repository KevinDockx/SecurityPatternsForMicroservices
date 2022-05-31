using System;
using System.Collections.Generic;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class BasketCheckout
    {
        public Guid BasketId { get; set; }

        //user info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Guid UserId { get; set; }
         
    }
}
