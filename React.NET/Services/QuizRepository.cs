using React.NET.Entities;
using React.NET.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Services
{
    public class QuizRepository
    {
        private QuizContext _context;

        public QuizRepository(QuizContext context)
        {
            _context = context;
        }

        public void AddQuestion(Question question)
        {
            question.Id = Guid.NewGuid();
            _context.Questions.Add(question);

            if (question.Answers.Any())
            {
                foreach (var answer in question.Answers)
                {
                    answer.Id = Guid.NewGuid();
                }
            }
        }

        public void AddAnswerToQuestion(Guid questionId, Answer answer)
        {
            var question = GetQuestion(questionId);
            if (question != null)
            {
                if (answer.Id == null)
                {
                    answer.Id = Guid.NewGuid();
                }
                question.Answers.Add(answer);
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

        public void DeleteAnswer(Answer answer)
        {
            _context.Answers.Remove(answer);
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
                var genreForWhereClause = questionsResourceParameters.QuestionText
                    .Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging
                    .Where(a => a.QuestionText.ToLowerInvariant() == genreForWhereClause);
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

        public Answer GetAnswerForQuestion(Guid questionId, Guid answerId)
        {
            var answers = _context.Answers
              .Where(b => b.QuestionId == questionId && b.Id == answerId).FirstOrDefault();

            return answers;
        }

        public IEnumerable<Answer> GetAnswersForQuestion(Guid questionId)
        {
            return _context.Answers
                        .Where(b => b.QuestionId == questionId).ToList();
        }

    }
}
