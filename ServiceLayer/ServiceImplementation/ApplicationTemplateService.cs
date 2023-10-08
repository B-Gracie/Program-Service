using ServiceLayer.ServiceInterface;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;

namespace ServiceLayer.ServiceImplementation
{
    public class ApplicationTemplateService : IApplicationTemplateService
    {
        private readonly IApplicationTemplateRepo _repository;

        public ApplicationTemplateService(IApplicationTemplateRepo repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationTemplateModel> GetApplicationTemplateAsync(string id)
        {
            return await _repository.GetApplicationTemplateAsync(id);
        }

        public async Task<ApplicationQuestionModel> GetQuestionAsync(string templateId, string questionId)
        {
            return await _repository.GetQuestionAsync(templateId, questionId);
        }

        public async Task<ApplicationQuestionModel> AddQuestionAsync(string templateId, ApplicationQuestionModel question)
        {
            return await _repository.AddQuestionAsync(templateId, question);
        }

        public async Task<ApplicationQuestionModel> UpdateQuestionAsync(string templateId, ApplicationQuestionModel question)
        {
            return await _repository.UpdateQuestionAsync(templateId, question);
        }

        public async Task<bool> DeleteQuestionAsync(string templateId, string questionId)
        {
            return await _repository.DeleteQuestionAsync(templateId, questionId);
        }
    }
}
