using React.NET.Entities;
using React.NET.Helpers;
using System;
using System.Collections.Generic;

namespace React.NET.Services
{
    public interface IQuizRepository
    {
        void AddQuestion(Question question);
        void AddAnswerToQuestion(Guid questionId, Answer answer);
        bool QuestionExists(Guid questionId);
        void DeleteQuestion(Question question);
        void DeleteAnswer(Answer answer);
        Question GetQuestion(Guid questionId);
        PagedList<Question> GetQuestions(QuestionsResourceParameters questionsResourceParameters);
        Answer GetAnswerForQuestion(Guid questionId, Guid answerId);
        IEnumerable<Answer> GetAnswersForQuestion(Guid questionId);
        void SaveUserEntryForQuestion(Entry entry);
        void CreateNewUser(User user);
        int CalculateScoreForQuiz(Guid userId);
        bool Save();
    }
}
