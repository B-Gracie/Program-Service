using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.@interface;

public interface IProgramPreviewRepo
{
    Task<ProgramPreviewModel> GetProgramPreviewAsync(string programId);
}