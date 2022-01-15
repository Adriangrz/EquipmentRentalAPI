﻿using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface IRentRepository
    {
        Task<IEnumerable<Rent>> GetAllAsync();
        Task InsertAsync(Rent rent);
        void Update(Rent rent);
        Task UpdateIssuedFieldAsync(Guid id, bool isIssued, DateTime issuedDate);
        Task UpdateReturnedFieldAsync(Guid id, bool isReturned, DateTime returnedDate);
    }
}