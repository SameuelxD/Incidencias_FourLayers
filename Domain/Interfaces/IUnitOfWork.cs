using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        ICityRepository Cities { get; }
        ICountryRepository Countries { get; }
        ICourseRepository Courses { get; }
        IDepartmentRepository Departments { get; }
        IGenreRepository Genres { get; }
        IPersonRepository People { get; }
        ITrainerCourseRepository TrainerCourses { get; }
        ITuitionRepository Tuitions { get; }
        ITypePersonRepository TypePeople { get; }
        Task<int> SaveAsync();

    }
}