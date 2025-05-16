using AutoMapper;
using BootcampProject.Business.Interfaces;
using BootcampProject.Entities.Concrete;
using BootcampProject.Entities.DTOs;
using BootcampProject.Repositories.Repositories;

namespace BootcampProject.Business.Managers
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper; // Mapper tanımı

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<List<InstructorDto>> GetAllAsync()
        {
            var instructors = await _instructorRepository.GetAllAsync();
            var dtoList = _mapper.Map<List<InstructorDto>>(instructors); // Mapping burada
            return dtoList;
        }

        public async Task<InstructorDto> GetByIdAsync(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            return _mapper.Map<InstructorDto>(instructor); // Mapping
        }

        public async Task AddAsync(InstructorDto dto)
        {
            var instructor = _mapper.Map<Instructor>(dto); // Mapping
            await _instructorRepository.AddAsync(instructor);
        }

        public async Task UpdateAsync(InstructorDto dto)
        {
            var instructor = _mapper.Map<Instructor>(dto); // Mapping
            await _instructorRepository.UpdateAsync(instructor);
        }

        public async Task DeleteAsync(int id)
        {
            await _instructorRepository.DeleteAsync(id);
        }
    }
}
