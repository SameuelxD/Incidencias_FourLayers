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
    public class AuditoriaController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TypePersonDto>>> Get()
        {
            var typepeople = await _unitOfWork.TypePeople.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<TypePersonDto>>(typepeople);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypePerson>> Post(TypePersonDto typepersonDto)
        {
            var typeperson = _mapper.Map<TypePerson>(typepersonDto);
            this._unitOfWork.TypePeople.Add(typeperson);
            await _unitOfWork.SaveAsync();
            if (typeperson == null)
            {
                return BadRequest();
            }
            typepersonDto.Id = typeperson.Id;
            return CreatedAtAction(nameof(Post), new { id = typepersonDto.Id }, typepersonDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypePersonDto>> Get(int id)
        {
            var typeperson = await _unitOfWork.TypePeople.GetByIdAsync(id);
            if (typeperson == null){
                return NotFound();
            }
            return _mapper.Map<TypePersonDto>(typeperson);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TypePersonDto>> Put(int id, [FromBody] TypePersonDto typepersonDto)
        {
            if (typepersonDto == null)
            {
                return NotFound();
            }
            var typepeople = _mapper.Map<TypePerson>(typepersonDto);
            _unitOfWork.TypePeople.Update(typepeople);
            await _unitOfWork.SaveAsync();
            return typepersonDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var typeperson = await _unitOfWork.TypePeople.GetByIdAsync(id);
            if (typeperson == null)
            {
                return NotFound();
            }
            _unitOfWork.TypePeople.Remove(typeperson);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

