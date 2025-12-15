
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApirestful.DataAccess;
using WebApirestful.DTOs;  

[ApiController]
[Route("api/GetWeather")]
public class WeatherCastController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public WeatherCastController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WeatherCastDto>>> GetWeatherCasts()
    {
        var weatherCasts = await _context.WeatherCasts.ToListAsync();
        
        var productDtos = _mapper.Map<IEnumerable<WeatherCastDto>>(weatherCasts);
        
        return Ok(productDtos);
    }
}
