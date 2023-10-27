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
    public class AddressController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
        {
            var addresses = await _unitOfWork.Addresses.GetAllAsync();

            //var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<AddressDto>>(addresses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Address>> Post(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);
            this._unitOfWork.Addresses.Add(address);
            await _unitOfWork.SaveAsync();
            if (address == null)
            {
                return BadRequest();
            }
            addressDto.Id = address.Id;
            return CreatedAtAction(nameof(Post), new { id = addressDto.Id }, addressDto);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AddressDto>> Get(int id)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return _mapper.Map<AddressDto>(address);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddressDto>> Put(int id, [FromBody] AddressDto addressDto)
        {
            if (addressDto == null)
            {
                return NotFound();
            }
            var addresses = _mapper.Map<Address>(addressDto);
            _unitOfWork.Addresses.Update(addresses);
            await _unitOfWork.SaveAsync();
            return addressDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            _unitOfWork.Addresses.Remove(address);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}