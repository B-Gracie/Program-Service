using DataAccessLayer.CosmosClient;
using DataAccessLayer.Model;
using Microsoft.Azure.Cosmos;
using DataAccessLayer.Repository.@interface;

namespace DataAccessLayer.Repository.Implementation
{
    public class ApplicationTemplateRepository : IApplicationTemplateRepo
    {
        private readonly Microsoft.Azure.Cosmos.CosmosClient _cosmosClient;
        private readonly string _containerName = "ApplicationTemplateContainer"; // Replace with your actual container name

        public ApplicationTemplateRepository(CosmosClientProvider cosmosClientProvider)
        {
            _cosmosClient = cosmosClientProvider.GetCosmosClient();
        }

        public async Task<ApplicationTemplateModel> GetApplicationTemplateAsync(string id)
        {
            try
            {
                var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
                var response = await container.ReadItemAsync<ApplicationTemplateModel>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle not found
                return null;
            }
        }

        public async Task<ApplicationTemplateModel> UpdateApplicationTemplateAsync(ApplicationTemplateModel template)
        {
            var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
            var response = await container.UpsertItemAsync(template, new PartitionKey(template.Id));
            return response.Resource;
        }

        public async Task<ApplicationQuestionModel> GetQuestionAsync(string templateId, string questionId)
        {
            var template = await GetApplicationTemplateAsync(templateId);
            if (template != null)
            {
                return template.Questions.FirstOrDefault(q => q.Id == questionId);
            }

            return null;
        }

        public async Task<ApplicationQuestionModel> AddQuestionAsync(string templateId, ApplicationQuestionModel question)
        {
            var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
            var template = await GetApplicationTemplateAsync(templateId);
            if (template != null)
            {
                template.Questions.Add(question);
                await UpdateApplicationTemplateAsync(template);
                return question;
            }

            return null;
        }

        public async Task<ApplicationQuestionModel> UpdateQuestionAsync(string templateId, ApplicationQuestionModel question)
        {
            var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
            var template = await GetApplicationTemplateAsync(templateId);
            if (template != null)
            {
                var existingQuestion = template.Questions.FirstOrDefault(q => q.Id == question.Id);
                if (existingQuestion != null)
                {
                    // Update the existing question properties
                    // You can add additional validation and update logic here as needed
                    existingQuestion.Type = question.Type;
                    existingQuestion.Text = question.Text;
                    existingQuestion.IsMandatory = question.IsMandatory;
                    // Update other properties as needed

                    await UpdateApplicationTemplateAsync(template);
                    return existingQuestion;
                }
            }

            return null;
        }

        public async Task<bool> DeleteQuestionAsync(string templateId, string questionId)
        {
            var container = _cosmosClient.GetContainer("ProgramDB", _containerName); // Specify the database name and container name
            var template = await GetApplicationTemplateAsync(templateId);
            if (template != null)
            {
                var questionToDelete = template.Questions.FirstOrDefault(q => q.Id == questionId);
                if (questionToDelete != null)
                {
                    template.Questions.Remove(questionToDelete);
                    await UpdateApplicationTemplateAsync(template);
                    return true;
                }
            }

            return false;
        }
    }
}
