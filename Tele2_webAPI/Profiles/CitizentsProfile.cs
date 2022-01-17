using Tele2_webAPI.Models;
using Tele2_webAPI.Dtos;
using AutoMapper;

namespace Tele2_webAPI.Profiles
{
    public class CitizentsProfile : Profile
    {
        public CitizentsProfile()
        {
            CreateMap<Citizen, CitizenReadDto>();
        }
    }
}
