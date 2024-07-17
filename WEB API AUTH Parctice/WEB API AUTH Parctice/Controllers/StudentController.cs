using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_AUTH_Parctice.Model.DTO;
using WEB_API_AUTH_Parctice.Repository;

namespace WEB_API_AUTH_Parctice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentRepository studentRepository) : ControllerBase
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    [HttpGet]
    [Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetAllStudent()
    {
        var data = await _studentRepository.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("id")]
    [Authorize(Roles = "Reader , Writer")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var data = await _studentRepository.GetByIdAsync(x=>x.Id == id);
        return Ok(data);
    }

    [HttpPost]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> CreateStudent(VmStudent student)
    {
        var data = await _studentRepository.CreateAsync(student);
        return Ok(data);
    }

    [HttpPut]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> UpdateStudent(int id,VmStudent student)
    {
        if(id == student.Id)
        {
            var data = await _studentRepository.UpdateAsync(id, student);
            return Ok(data);
        }
        return BadRequest("ID MisMatch");
    }

    [HttpDelete]
    [Authorize(Roles = "Writer")]
    public async Task<IActionResult> DeleteStudent(int id) => Ok(await _studentRepository.DeleteAsync(id));
}
