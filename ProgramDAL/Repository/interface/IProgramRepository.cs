using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.@interface;

public interface IProgramRepository
{
    Task<IEnumerable<ProgramModel>> GetProgramsAsync();
    Task<ProgramModel> GetProgramAsync(string id);
    Task<ProgramModel> CreateProgramAsync(ProgramModel program);
    

    Task<ProgramModel> UpdateProgramAsync(string id, ProgramModel program);
    Task<bool> DeleteProgramAsync(string id);
   // Task<ProgramModel> SaveProgramAsync(ProgramModel program);

}