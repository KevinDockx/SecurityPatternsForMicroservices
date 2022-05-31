﻿using GloboTicket.Services.ShoppingBasket.Models;
using System;
using System.Threading.Tasks;

namespace GloboTicket.Services.ShoppingBasket.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetCoupon(Guid userId);
    }
}
