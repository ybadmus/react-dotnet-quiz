using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using React.NET.Models;
using React.NET.Services;

namespace React.NET.Controllers
{
    [Route("api/PossibleAnswers")]
    public class PossibleAnswersController : Controller
    {
        private IQuizRepository _quizRepository;
        public PossibleAnswersController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpGet("GetPossibleAnswersForQuestion", Name = "GetPossibleAnswersForQuestion")]
        public IActionResult GetPossibleAnswersForQuestion(Guid questionId)
        {
            var possibleAnswersFromRepo = _quizRepository.GetPossibleAnswersForQuestion(questionId);

            if (possibleAnswersFromRepo == null)
            {
                return NotFound();
            }

            var possibleAnswers = Mapper.Map<IEnumerable<PossibleAnswerDto>>(possibleAnswersFromRepo);
            return Ok(possibleAnswers);
        }
        
        [HttpGet("GetAnswersForQuestion", Name = "GetAnswersForQuestion")]
        public IActionResult GetAnswersForQuestion(Guid questionId)
        {
            var answersFromRepo = _quizRepository.GetAnswersForQuestion(questionId);

            if (answersFromRepo == null)
            {
                return NotFound();
            }

            var answers = Mapper.Map<IEnumerable<PossibleAnswerDto>>(answersFromRepo);
            return Ok(answers);
        }

        [HttpGet("GetPossibleAnswersAndAnswers", Name = "GetPossibleAnswersAndAnswers")]
        public IActionResult GetPossibleAnswersAndAnswers(Guid questionId)
        {
            var possibleAnswersFromRepo = _quizRepository.GetPossibleAnswersForQuestion(questionId);
            var answersFromRepo = _quizRepository.GetAnswersForQuestion(questionId);

            if (answersFromRepo == null && possibleAnswersFromRepo == null)
            {
                return NotFound();
            }

            var possibleAnswers = Mapper.Map<IEnumerable<PossibleAnswerDto>>(possibleAnswersFromRepo);
            var answers = Mapper.Map<IEnumerable<PossibleAnswerDto>>(answersFromRepo);

            var possibleAnswersAndAnswersObj = new PossibleAnswersAndAnswersDto()
            {
                PossibleAnswers = possibleAnswers,
                Answers = answers
            };

            return Ok(possibleAnswersAndAnswersObj);
        }
    }
}
