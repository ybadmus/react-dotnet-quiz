using React.NET.Entities;
using React.NET.Helpers;
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
        PossibleAnswer GetAnswerForQuestion(Guid questionId, Guid answerId);
        IEnumerable<PossibleAnswer> GetPossibleAnswersForQuestion(Guid questionId);
        void SaveUserEntryForQuestion(Entry entry);
        Guid CreateNewUser(User user);
        int CalculateScoreForQuiz(Guid userId);
        bool Save();
    }
}
