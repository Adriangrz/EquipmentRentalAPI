﻿using EquipmentRental.Database;
using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using EquipmentRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services
{
    public class SportEquipmentService : ISportEquipmentService
    {
        private readonly ISportEquipmentRepository _sportEquipmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SportEquipmentService(ISportEquipmentRepository sportEquipmentRepository, IUnitOfWork unitOfWork)
        {
            _sportEquipmentRepository = sportEquipmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _sportEquipmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SportEquipment>> GetAllAsync()
        {
            return await _sportEquipmentRepository.GetAllAsync();
        }

        public async Task InsertAsync(SportEquipment equipment)
        {
            await _sportEquipmentRepository.InsertAsync(equipment);
        }

        public void Update(SportEquipment equipment)
        {
            _sportEquipmentRepository.Update(equipment);
        }
    }
}
