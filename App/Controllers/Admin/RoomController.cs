using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Rooms;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers.Admin
{

    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RoomCreateDto request)
        {
            await _roomService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { Response = "succesfull" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roomService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            return Ok(await _roomService.GetByIdAsync(id));
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, RoomEditDto request)
        {
            await _roomService.EditAsync(id, request);

            return Ok(new { response = "Data successfully updated" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _roomService.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }
    }
}
