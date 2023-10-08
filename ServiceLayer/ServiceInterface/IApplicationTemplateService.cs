using DataAccessLayer.Model;

namespace ServiceLayer.ServiceInterface
{
    using System.Threading.Tasks;
    using DataAccessLayer.Model;
}

namespace ServiceLayer.ServiceInterface
{
    public interface IApplicationTemplateService
    {
        Task<ApplicationTemplateModel> GetApplicationTemplateAsync(string id);
        
        Task<ApplicationQuestionModel> GetQuestionAsync(string templateId, string questionId);
        Task<ApplicationQuestionModel> AddQuestionAsync(string templateId, ApplicationQuestionModel question);
        Task<ApplicationQuestionModel> UpdateQuestionAsync(string templateId, ApplicationQuestionModel question);
        Task<bool> DeleteQuestionAsync(string templateId, string questionId);
    }
}
