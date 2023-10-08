using DataAccessLayer.Model;

namespace ServiceLayer.ServiceInterface;

public interface IProgramPreviewService
{
    Task<ProgramPreviewModel> GetProgramPreviewAsync(string programId);
}
