using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Add(Student student)
    {
        return Ok(await _service.Add(student));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Student student)
    {
        return Ok(await _service.Update(student));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _service.Delete(id));
    }
}