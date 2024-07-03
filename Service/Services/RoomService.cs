using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Teachers;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository roomRepo,
                          IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(RoomCreateDto model)
        {
            await _roomRepo.CreateAsync(_mapper.Map<Room>(model));
        }

        public async  Task DeleteAsync(int? id)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var room = await _roomRepo.FindBy(m => m.Id == id).FirstOrDefaultAsync() ?? throw new NotFoundException("Data not found");

            await _roomRepo.DeleteAsync(room);
        }

        public async  Task EditAsync(int? id, RoomEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));
            ArgumentNullException.ThrowIfNull(nameof(model));

            var room = await _roomRepo.FindBy(m => m.Id == id).FirstOrDefaultAsync() ?? throw new NotFoundException("Data not found");

            _mapper.Map(model, room);
            await _roomRepo.EditAsync(room);
        }


        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<RoomDto>>(await _roomRepo.GetAllAsync());
        }

        public async  Task<RoomDto> GetByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            var existRoom = await _roomRepo.GetById((int)id);

            if (existRoom == null) throw new NullReferenceException();

            return _mapper.Map<RoomDto>(existRoom);
        }
    }
}
