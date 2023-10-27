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
    public class TuitionController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public TuitionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TuitionDto>>> Get()
        {
            var tuitions = await _unitOfWork.Tuitions.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<TuitionDto>>(tuitions);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tuition>> Post(TuitionDto tuitionDto)
        {
            var tuition = _mapper.Map<Tuition>(tuitionDto);
            this._unitOfWork.Tuitions.Add(tuition);
            await _unitOfWork.SaveAsync();
            if (tuition == null)
            {
                return BadRequest();
            }
            tuitionDto.Id = tuition.Id;
            return CreatedAtAction(nameof(Post), new { id = tuitionDto.Id }, tuitionDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TuitionDto>> Get(int id)
        {
            var tuition = await _unitOfWork.Tuitions.GetByIdAsync(id);
            if (tuition == null){
                return NotFound();
            }
            return _mapper.Map<TuitionDto>(tuition);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TuitionDto>> Put(int id, [FromBody] TuitionDto tuitionDto)
        {
            if (tuitionDto == null)
            {
                return NotFound();
            }
            var tuitions = _mapper.Map<Tuition>(tuitionDto);
            _unitOfWork.Tuitions.Update(tuitions);
            await _unitOfWork.SaveAsync();
            return tuitionDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var tuition = await _unitOfWork.Tuitions.GetByIdAsync(id);
            if (tuition == null)
            {
                return NotFound();
            }
            _unitOfWork.Tuitions.Remove(tuition);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
