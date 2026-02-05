using AutoMapper;
using CarShop.Data;
using CarShop.Dtos;
using CarShop.Entityes;
using CarShop.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
       
        private readonly IMapper _mapper;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Category> _categoryRepository;

        public CarService(IMapper mapper, IRepository<Car> carRepository, IRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CarResponseDto> CreateAsync(CreateCarDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);

            if (category == null)
                throw new ArgumentException("Category not found");

            var car = _mapper.Map<Car>(dto);

            car.CategoryId = dto.CategoryId;
            car.Category = category;

            await _carRepository.AddAsync(car);
            await _carRepository.SaveChangesAsync();
            return _mapper.Map<CarResponseDto>(car);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car == null)
                return false;

            _carRepository.Delete(car);
            await _carRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<CarResponseDto>> GetAllAsync()
        {
            var cars = await _carRepository.ListAllAsync();
            return _mapper.Map<List<CarResponseDto>>(cars);
        }

        public async Task<CarResponseDto> GetByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car == null)
                return null;

            return _mapper.Map<CarResponseDto>(car);
        }

        public async Task<CarResponseDto> UpdateAsync(int id, UpdateCarDto dto)
        {
            var car = await _carRepository.GetByIdAsync(id);

            if (car == null)
                return null;

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);

            if (category == null)
                throw new ArgumentException("Category Not Found");

            car.CategoryId = dto.CategoryId;
            car.Category = category;

            _carRepository.Update(car);

            await _carRepository.SaveChangesAsync();

            return _mapper.Map<CarResponseDto>(car);
        }
    }
}
