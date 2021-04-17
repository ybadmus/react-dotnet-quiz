using React.NET.Entities;
using React.NET.Helpers;
using React.NET.Models;
using System;
using System.Collections.Generic;

namespace React.NET.Services
{
    public interface IQuizRepository
    {
        void AddQuestion(Question question);
        void AddAnswerToQuestion(Guid questionId, PossibleAnswer answer);
        bool QuestionExists(Guid questionId);
        void DeleteQuestion(Question question);
        void DeleteAnswer(PossibleAnswer answer);
        Question GetQuestion(Guid questionId);
        PagedList<Question> GetQuestions(QuestionsResourceParameters questionsResourceParameters);
        IEnumerable<Question> GetQuestionsWithListOfId(IEnumerable<Guid> questionIds);
        IEnumerable<PossibleAnswer> GetPossibleAnswers();
        PossibleAnswer GetAnswerForQuestion(Guid questionId, Guid answerId);
        IEnumerable<PossibleAnswer> GetPossibleAnswersForQuestion(Guid questionId);
        IEnumerable<PossibleAnswer> GetAnswersForQuestion(Guid questionId);
        void SaveEntryForQuestion(UserSelectionsForCreationDto selection);
        Guid CreateUser(User user);
        UserScoreDto CalculateScoreForQuiz(Guid userId);
        bool Save();
    }
}
