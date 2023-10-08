using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using ServiceLayer.ServiceInterface;

namespace ServiceLayer.ServiceImplementation;
public class ProgramPreviewService : IProgramPreviewService
{
    private readonly IProgramPreviewRepo _repository;

    public ProgramPreviewService(IProgramPreviewRepo repository)
    {
        _repository = repository;
    }

    public async Task<ProgramPreviewModel> GetProgramPreviewAsync(string programId)
    {
        return await _repository.GetProgramPreviewAsync(programId);
    }
}
