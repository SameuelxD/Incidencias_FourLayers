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
    public class TrainerCourseController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public TrainerCourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TrainerCourseDto>>> Get()
        {
            var trainercourses = await _unitOfWork.TrainerCourses.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<TrainerCourseDto>>(trainercourses);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TrainerCourse>> Post(TrainerCourseDto trainercourseDto)
        {
            var trainercourse = _mapper.Map<TrainerCourse>(trainercourseDto);
            this._unitOfWork.TrainerCourses.Add(trainercourse);
            await _unitOfWork.SaveAsync();
            if (trainercourse == null)
            {
                return BadRequest();
            }
            trainercourseDto.Id = trainercourse.Id;
            return CreatedAtAction(nameof(Post), new { id = trainercourseDto.Id }, trainercourseDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrainerCourseDto>> Get(int id)
        {
            var trainercourse = await _unitOfWork.TrainerCourses.GetByIdAsync(id);
            if (trainercourse == null){
                return NotFound();
            }
            return _mapper.Map<TrainerCourseDto>(trainercourse);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TrainerCourseDto>> Put(int id, [FromBody] TrainerCourseDto trainercourseDto)
        {
            if (trainercourseDto == null)
            {
                return NotFound();
            }
            var trainercourses = _mapper.Map<TrainerCourse>(trainercourseDto);
            _unitOfWork.TrainerCourses.Update(trainercourses);
            await _unitOfWork.SaveAsync();
            return trainercourseDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var trainercourse = await _unitOfWork.TrainerCourses.GetByIdAsync(id);
            if (trainercourse == null)
            {
                return NotFound();
            }
            _unitOfWork.TrainerCourses.Remove(trainercourse);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
