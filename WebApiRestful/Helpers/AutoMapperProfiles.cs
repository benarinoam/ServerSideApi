// Helpers/AutoMapperProfiles.cs
using AutoMapper;
using WebApirestful.Models;
using WebApirestful.DTOs;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Define the mapping: source -> destination
        CreateMap<WeatherCast, WeatherCastDto>();
    }
}
