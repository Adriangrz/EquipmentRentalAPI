using EquipmentRental.Database;
using EquipmentRental.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EquipmentRentalContext _context;
        private ICategoryRepository _categoryRepository;
        private IRentRepository _rentRepository;
        private ISportEquipmentRepository _sportEquipmentRepository;
        private IUserRepository _userRepository;

        public ICategoryRepository CategoryRepository { 
            get {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            } 
        }
        public IRentRepository RentRepository {
            get
            {
                if (_rentRepository == null)
                {
                    _rentRepository = new RentRepository(_context);
                }
                return _rentRepository;
            }
        }
        public ISportEquipmentRepository SportEquipmentRepository {
            get
            {
                if (_sportEquipmentRepository == null)
                {
                    _sportEquipmentRepository = new SportEquipmentRepository(_context);
                }
                return _sportEquipmentRepository;
            }
        }
        public IUserRepository UserRepository {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public UnitOfWork(EquipmentRentalContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
