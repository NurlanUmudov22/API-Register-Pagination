using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Teachers;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers.Admin
{

    public class TeacherController : BaseController
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService teacherService)
        {
            _service = teacherService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherCreateDto request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { Response = "Data succesfully created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id , TeacherEditDto request)
        {
            await _service.EditAsync(id, request);

            return Ok(new { response = "Data successfully updated" });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            return Ok(await _service.GetByIdAsync(id));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }
    }
}
