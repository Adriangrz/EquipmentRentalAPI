﻿using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface ISportEquipmentService
    {
        Task<IEnumerable<SportEquipment>> GetAllAsync();
        Task InsertAsync(SportEquipment equipment);
        void Update(SportEquipment equipment);
        Task DeleteAsync(Guid id);
    }
}