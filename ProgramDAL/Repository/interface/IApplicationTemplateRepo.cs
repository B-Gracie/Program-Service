using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.@interface;

public interface IApplicationTemplateRepo
{
    Task<ApplicationTemplateModel> GetApplicationTemplateAsync(string id);
    Task<ApplicationQuestionModel> GetQuestionAsync(string templateId, string questionId);
    Task<ApplicationTemplateModel> UpdateApplicationTemplateAsync(ApplicationTemplateModel template);
    
    Task<ApplicationQuestionModel> AddQuestionAsync(string templateId, ApplicationQuestionModel question);
    Task<ApplicationQuestionModel> UpdateQuestionAsync(string templateId, ApplicationQuestionModel question);
    Task<bool> DeleteQuestionAsync(string templateId, string questionId);

}