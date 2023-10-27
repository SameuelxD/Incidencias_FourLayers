using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entitites;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository
{
    public class TuitionRepository : GenericRepository<Tuition>, ITuitionRepository
    {
        public TuitionRepository(IncidenciasContext context) : base(context)
        {
        }
    }
}