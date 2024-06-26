﻿using AutoMapper;
using LXP.Common.DTO;
using LXP.Core.IServices;
using LXP.Data.IRepository;

namespace LXP.Core.Services
{
    public class TopicFeedbackService : ITopicFeedbackService
    {
        private readonly ITopicFeedbackRepository _repository;

        public TopicFeedbackService(ITopicFeedbackRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TopicFeedbackQuestionNoDTO> GetAllFeedbackQuestions()
        {
            return _repository.GetAllFeedbackQuestions();
        }

        public TopicFeedbackQuestionNoDTO GetFeedbackQuestionById(Guid id)
        {
            return _repository.GetFeedbackQuestionById(id);
        }

        public void SubmitFeedbackResponse(TopicFeedbackResponseDTO feedbackResponse)
        {
            _repository.AddFeedbackResponse(feedbackResponse);
        }

        public bool AddFeedbackQuestion(TopicFeedbackQuestionDTO question, List<FeedbackOptionDTO> options)
        {
            
            return _repository.AddFeedbackQuestion(question, options);
        }

        public bool UpdateFeedbackQuestion(Guid id, TopicFeedbackQuestionDTO question, List<FeedbackOptionDTO> options)
        {
            // Validation and business logic here
            if (question == null)
                return false;

            if (string.IsNullOrEmpty(question.Question))
                return false;

            if (question.QuestionType == "MCQ" && (question.Options == null || question.Options.Count < 2 || question.Options.Count > 5))
                return false;

            return _repository.UpdateFeedbackQuestion(id, question,options);
        }

        public bool DeleteFeedbackQuestion(Guid id)
        {
            return _repository.DeleteFeedbackQuestion(id);
        }

        // Implement other service methods
    }
}
