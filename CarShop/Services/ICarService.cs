using CarShop.Dtos;

namespace CarShop.Services
{
    public interface ICarService
    {
        Task<List<CarResponseDto>> GetAllAsync();
        Task<CarResponseDto> GetByIdAsync(int id);
        Task<CarResponseDto> CreateAsync(CreateCarDto dto);
        Task<CarResponseDto> UpdateAsync(int id, UpdateCarDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
