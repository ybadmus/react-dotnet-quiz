﻿using Microsoft.Extensions.Configuration;
using React.NET.Entities;
using React.NET.Helpers;
using React.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace React.NET.Services
{
    public class QuizRepository : IQuizRepository
    {
        private QuizContext _context;
        public IConfiguration Configuration { get; }

        public QuizRepository(QuizContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
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

        public void SaveEntryForQuestion(Entry entry)
        {
            if (entry.Id == null)
            {
                entry.Id = Guid.NewGuid();
            }

            var noUserEntries = _context.Entries.Where(u => u.UserId == entry.UserId).ToList().Count();

            if (noUserEntries >= Convert.ToInt32(Configuration.GetConnectionString("totalNoOfQuizes")))
            {
                throw new Exception($"Total number of entry for user exceeded");

            }

            _context.Entries.Add(entry);
        }

        public Guid CreateUser(User user)
        {
            if (user.Id == null)
            {
                user.Id = Guid.NewGuid();
            }
            _context.Users.Add(user);
            return user.Id;
        }

        public Guid LoginUserWithUsername(String username)
        {
            return _context.Users
                .Where(u => u.Username == username).FirstOrDefault().Id;
        }

        public UserScoreDto CalculateScoreForQuiz(Guid userId)
        {
            var score = new UserScoreDto();
            if(userId != Guid.Empty) {
                var entriesFromRepo = _context.Entries.Where(b => b.UserId == userId).Select(b => b.Correct);
                var username = _context.Users.Where(u => u.Id == userId).FirstOrDefault().Username;
                score.Username = username;
                score.Score =  ((Decimal)entriesFromRepo.Count() / Convert.ToDecimal(Configuration.GetConnectionString("totalNoOfQuizes"))) * 100;

                return score;
            }

            return score;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
