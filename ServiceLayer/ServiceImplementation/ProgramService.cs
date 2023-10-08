using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using Microsoft.Azure.Cosmos;
using ServiceLayer.ServiceInterface;

namespace ServiceLayer.ServiceImplementation
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;

        public ProgramService(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramModel>> GetProgramsAsync()
        {
            return await _programRepository.GetProgramsAsync();
        }

        public async Task<ProgramModel> GetProgramAsync(string id)
        {
            return await _programRepository.GetProgramAsync(id);
        }

        public async Task<ProgramDto> CreateProgramAsync(ProgramDto programDto)
        {
            try
            {
                // Generate a unique id on the server-side
                string uniqueId = Guid.NewGuid().ToString();

                // Map 'programDto' to 'ProgramModel' and set the generated 'Id'
                var programModel = _mapper.Map<ProgramModel>(programDto);
                programModel.Id = uniqueId;

                // Save 'programModel' to Cosmos DB
                var createdProgram = await _programRepository.CreateProgramAsync(programModel);

                // Map the created 'ProgramModel' back to 'ProgramDto' before returning
                return _mapper.Map<ProgramDto>(createdProgram);
            }
            catch (CosmosException ex)
            {
                // Handle any Cosmos DB-related exceptions here, e.g., logging, error response
                throw ex;
            }
        }






        public async Task<ProgramModel> UpdateProgramAsync(string id, ProgramModel program)
        {
            return await _programRepository.UpdateProgramAsync(id, program);
        }

        public async Task<bool> DeleteProgramAsync(string id)
        {
            return await _programRepository.DeleteProgramAsync(id);
        }
    }
}
