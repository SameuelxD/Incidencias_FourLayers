using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entitites;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IncidenciasContext _context;
        private AddressRepository _addresses;
        public GenreRepository _genres;
        private CityRepository _cities;
        private CountryRepository _countries;
        private CourseRepository _courses;
        private DepartmentRepository _departments;
        private PersonRepository _people;
        private TrainerCourseRepository _trainercourses;
        private TuitionRepository _tuitions;
        private TypePersonRepository _typepeople;
        public IAddressRepository Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new AddressRepository(_context);
                }
                return _addresses;
            }
        }

        public ICityRepository Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new CityRepository(_context);
                }
                return _cities;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CountryRepository(_context);
                }
                return _countries;
            }
        }

        public ICourseRepository Courses
        {
            get
            {
                if (_courses == null)
                {
                    _courses = new CourseRepository(_context);
                }
                return _courses;
            }
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new DepartmentRepository(_context);
                }
                return _departments;
            }
        }

        public IPersonRepository People
        {
            get
            {
                if (_people == null)
                {
                    _people = new PersonRepository(_context);
                }
                return _people;
            }
        }

        public ITrainerCourseRepository TrainerCourses
        {
            get
            {
                if (_trainercourses == null)
                {
                    _trainercourses = new TrainerCourseRepository(_context);
                }
                return _trainercourses;
            }
        }

        public ITuitionRepository Tuitions
        {
            get
            {
                if (_tuitions == null)
                {
                    _tuitions = new TuitionRepository(_context);
                }
                return _tuitions;
            }
        }

        public ITypePersonRepository TypePeople
        {
            get
            {
                if (_typepeople == null)
                {
                    _typepeople = new TypePersonRepository(_context);
                }
                return _typepeople;
            }
        }
        public IGenreRepository Genres
        {
            get
            {
                if (_genres == null)
                {
                    _genres = new GenreRepository(_context);
                }
                return _genres;
            }
        }


        public UnitOfWork(IncidenciasContext context)
        {
            _context = context;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}