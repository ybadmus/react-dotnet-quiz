using React.NET.Entities;
using React.NET.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace React.NET.Services
{
    public class QuizRepository : IQuizRepository
    {
        private QuizContext _context;

        public QuizRepository(QuizContext context)
        {
            _context = context;
        }

        public void AddQuestion(Question question)
        {
            if (question.Id == null)
            {
                question.Id = Guid.NewGuid();

            }
            _context.Questions.Add(question);

            if (question.PossibleAnswers.Any())
            {
                foreach (var answer in question.PossibleAnswers)
                {
                    answer.Id = Guid.NewGuid();
                }
            }
        }

        public void AddAnswerToQuestion(Guid questionId, PossibleAnswer answer)
        {
            var question = GetQuestion(questionId);
            if (question != null)
            {
                if (answer.Id == null)
                {
                    answer.Id = Guid.NewGuid();
                }
                question.PossibleAnswers.Add(answer);
            }
        }

        public bool QuestionExists(Guid questionId)
        {
            return _context.Questions.Any(a => a.Id == questionId);
        }

        public void DeleteQuestion(Question question)
        {
            _context.Questions.Remove(question);
        }

        public void DeleteAnswer(PossibleAnswer answer)
        {
            _context.PossibleAnswers.Remove(answer);
        }

        public Question GetQuestion(Guid questionId)
        {
            return _context.Questions.FirstOrDefault(a => a.Id == questionId);
        }

        public PagedList<Question> GetQuestions(QuestionsResourceParameters questionsResourceParameters)
        {
            var collectionBeforePaging =
                _context.Questions.AsQueryable();

            if (!string.IsNullOrEmpty(questionsResourceParameters.QuestionText))
            {
                var questionForWhereClause = questionsResourceParameters.QuestionText
                    .Trim().ToLowerInvariant();

                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.QuestionText.ToLowerInvariant() == questionForWhereClause);
            }

            if (!string.IsNullOrEmpty(questionsResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = questionsResourceParameters.SearchQuery
                    .Trim().ToLowerInvariant();

                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.QuestionText.ToLowerInvariant().Contains(searchQueryForWhereClause));
            }

            return PagedList<Question>.Create(collectionBeforePaging,
                questionsResourceParameters.PageNumber,
                questionsResourceParameters.PageSize);
        }

        public IEnumerable<Question> GetQuestionsWithListOfId(IEnumerable<Guid> questionIds)
        {
            return _context.Questions.Where(a => questionIds.Contains(a.Id)).ToList();
        }

        public PossibleAnswer GetAnswerForQuestion(Guid questionId, Guid answerId)
        {
            var PossibleAnswers = _context.PossibleAnswers
              .Where(b => b.QuestionId == questionId && b.Id == answerId).FirstOrDefault();

            return PossibleAnswers;
        }

        public IEnumerable<PossibleAnswer> GetPossibleAnswersForQuestion(Guid questionId)
        {
            return _context.PossibleAnswers
                        .Where(b => b.QuestionId == questionId).ToList();
        }

        public IEnumerable<PossibleAnswer> GetAnswersForQuestion(Guid questionId)
        {
            return _context.PossibleAnswers
                        .Where(b => b.QuestionId == questionId && b.Answer).ToList();
        }

        public void SaveUserEntryForQuestion(Entry entry)
        {
            if (entry.Id == null)
            {
                entry.Id = Guid.NewGuid();
            }
            _context.Entries.Add(entry);
        }

        public Guid CreateNewUser(User user)
        {
            user.Id = Guid.NewGuid();
            _context.Users.Add(user);
            return user.Id;
        }

        public Guid LoginUserWithUsername(String username)
        {
            return _context.Users
                .Where(u => u.Username == username).FirstOrDefault().Id;
        }

        public int CalculateScoreForQuiz(Guid userId)
        {
            var entries = _context.Entries.Where(b => b.UserId == userId).Select(b => b.Correct);
            return entries.Count();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
