using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}