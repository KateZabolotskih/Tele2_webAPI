using Microsoft.AspNetCore.Mvc;
using Tele2_webAPI.Controllers;
using System.Collections.Generic;
using Tele2_webAPI.Data;
using Tele2_webAPI.Models;
using AutoMapper;
using Tele2_webAPI.Dtos;

namespace Tele2_webAPI.Controllers
{   
    [ApiController]
    [Route("api/citizents")]
    public class CitizensController : Controller
    {
        private readonly ICityRepo _repository;
        private readonly IMapper _mapper;

        public CitizensController(ICityRepo repository, IMapper mapper)
        {
            _repository = repository;
            _repository.SettleCitizents();
            _repository.SaveChanges();
            _mapper = mapper;
        }

        //GET api/citizents
        [HttpGet("{sex?}/{lowerAgeLimit?}/{upperAgeLimit?}/{pageNumber?}/{pageSize?}")]
        public ActionResult<IEnumerable<CitizenReadDto>> GetAllResidents([FromQuery] string sex=null, [FromQuery] int lowAge=-1, [FromQuery] int upAge=-1, [FromQuery] int pageNum=-1, [FromQuery] int pageSize=-1)
        {
            var residents = _repository.GetCitizensByParams(sex, lowAge, upAge, pageNum, pageSize);
            
            return Ok(_mapper.Map<IEnumerable<CitizenReadDto>>(residents));
        }


        //GET api/citizents/{id}
        [HttpGet("{id}")]
        public ActionResult<CitizenReadDto> GetResidentById(string id)
        {
            var resident = _repository.GetCitizentById(id);
            if (resident != null)
            {
                return Ok(_mapper.Map<CitizenReadDto>(resident));
            }
            return NotFound();
        }

    }
}
