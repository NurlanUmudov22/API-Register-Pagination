using Service.DTOs.Admin.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ITeacherService
    {
        Task CreateAsync(TeacherCreateDto model );
        Task<IEnumerable<TeacherDto>> GetAllAsync();

        Task EditAsync(int? id,  TeacherEditDto model );

        Task<TeacherDto> GetByIdAsync(int? id);

        Task DeleteAsync(int? id);
    }
}
