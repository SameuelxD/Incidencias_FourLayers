using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GenreController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public GenreController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GenreDto>>> Get()
        {
            var genres = await _unitOfWork.Genres.GetAllAsync();
    
            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<GenreDto>>(genres);
        }
    
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Genre>> Post(GenreDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            this._unitOfWork.Genres.Add(genre);
            await _unitOfWork.SaveAsync();
            if (genre == null)
            {
                return BadRequest();
            }
            genreDto.Id = genre.Id;
            return CreatedAtAction(nameof(Post), new { id = genreDto.Id }, genreDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenreDto>> Get(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);
            if (genre == null){
                return NotFound();
            }
            return _mapper.Map<GenreDto>(genre);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenreDto>> Put(int id, [FromBody] GenreDto genreDto)
        {
            if (genreDto == null)
            {
                return NotFound();
            }
            var genres = _mapper.Map<Genre>(genreDto);
            _unitOfWork.Genres.Update(genres);
            await _unitOfWork.SaveAsync();
            return genreDto;
        }
    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            _unitOfWork.Genres.Remove(genre);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}

