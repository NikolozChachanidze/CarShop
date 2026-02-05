using AutoMapper;
using CarShop.Dtos;
using CarShop.Entityes;
using CarShop.Repositorys;

namespace CarShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IMapper mapper, IRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return false;

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IReadOnlyList<CategoryResponseDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.ListAllAsync();
            return _mapper.Map<List<CategoryResponseDto>>(categories);
        }

        public async Task<CategoryResponseDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return null;

            return _mapper.Map<CategoryResponseDto>(category);
        }

        public async Task<CategoryResponseDto> UpdateAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return null;

            _mapper.Map(dto, category);
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();

            return _mapper.Map<CategoryResponseDto>(category);
        }
    }
}
