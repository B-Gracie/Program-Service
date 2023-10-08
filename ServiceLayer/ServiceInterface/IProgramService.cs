using DataAccessLayer.DTOs;
using DataAccessLayer.Model;

namespace ServiceLayer.ServiceInterface
{
    public interface IProgramService
    {
        Task<IEnumerable<ProgramModel>> GetProgramsAsync();
        Task<ProgramModel> GetProgramAsync(string id);

        //Task<ProgramDto> CreateProgramAsync(string uniqueId);
        Task<ProgramDto> CreateProgramAsync(ProgramDto programDto);
        //Task<ProgramModel> CreateProgramAsync(ProgramModel programModel);

        //Task<ProgramModel> CreateProgramAsync(ProgramDto programDto);
        //Task<ProgramModel> CreateProgramAsync(ProgramModel program);
        Task<ProgramModel> UpdateProgramAsync(string id, ProgramModel program);
        Task<bool> DeleteProgramAsync(string id);
    }
}
