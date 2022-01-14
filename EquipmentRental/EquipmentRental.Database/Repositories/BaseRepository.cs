using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Database.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly EquipmentRentalContext _context;

        public BaseRepository(EquipmentRentalContext context)
        {
            _context = context;
        }
    }
}
