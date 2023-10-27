using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entitites;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CourseController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CourseDto>>> Get()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<CourseDto>>(courses);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Course>> Post(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            this._unitOfWork.Courses.Add(course);
            await _unitOfWork.SaveAsync();
            if (course == null)
            {
                return BadRequest();
            }
            courseDto.Id = course.Id;
            return CreatedAtAction(nameof(Post), new { id = courseDto.Id }, courseDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseDto>> Get(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null){
                return NotFound();
            }
            return _mapper.Map<CourseDto>(course);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CourseDto>> Put(int id, [FromBody] CourseDto courseDto)
        {
            if (courseDto == null)
            {
                return NotFound();
            }
            var courses = _mapper.Map<Course>(courseDto);
            _unitOfWork.Courses.Update(courses);
            await _unitOfWork.SaveAsync();
            return courseDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _unitOfWork.Courses.Remove(course);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}