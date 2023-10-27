using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}