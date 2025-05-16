using Microsoft.AspNetCore.Mvc;
using BootcampProject.Business.Interfaces;
using BootcampProject.Entities.DTOs;

namespace BootcampProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _instructorService.GetAllAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InstructorDto dto)
        {
            await _instructorService.AddAsync(dto);
            return Ok(new { message = "Eğitmen başarıyla eklendi." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InstructorDto dto)
        {
            await _instructorService.UpdateAsync(dto);
            return Ok(new { message = "Eğitmen başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _instructorService.DeleteAsync(id);
            return Ok(new { message = "Eğitmen başarıyla silindi." });
        }
    }
}
