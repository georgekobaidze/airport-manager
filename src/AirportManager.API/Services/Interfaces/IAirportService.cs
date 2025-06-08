using AirportManager.API.DTOs;
using AirportManager.API.Entities;

namespace AirportManager.API.Services.Interfaces;

public interface IAirportService
{
    Task<int> CreateAsync(CreateAirportDto createAirportDto);
    Task<IEnumerable<AirportDto>> GetAllAsync();
    Task<AirportDto> GetByIdAsync(int id);
    Task UpdateAsync(int id, UpdateAirportDto updateAirportDto);
}
