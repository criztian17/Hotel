﻿using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;
using System.Threading.Tasks;

namespace Hotel.Repository.Repositories.Interfaces
{
    public interface IBookingRepository : IBaseRepository<BookingEntity>
    {
        /// <summary>
        /// Generate the next booking number
        /// </summary>
        /// <returns>int</returns>
        int GenerateBookingNumber();
    }
}
