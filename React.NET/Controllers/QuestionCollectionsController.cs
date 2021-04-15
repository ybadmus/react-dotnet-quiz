using AutoMapper;
using React.NET.Entities;
using React.NET.Helpers;
using React.NET.Models;
using React.NET.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Controllers
{
    [Route("api/QuestionCollections")]
    public class QuestionCollectionsController : Controller
    {
        private IQuizRepository _quizRepository;

        public QuestionCollectionsController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpPost("CreateQuestionCollection", Name = "CreateQuestionCollection")]
        public IActionResult CreateQuestionCollection([FromBody] IEnumerable<QuestionForCreationDto> questionCollection)
        {
            if (questionCollection == null)
            {
                return BadRequest();
            }

            var questionEntities = Mapper.Map<IEnumerable<Question>>(questionCollection);

            foreach (var question in questionEntities)
            {
                _quizRepository.AddQuestion(question);
            }

            if (!_quizRepository.Save())
            {
                throw new Exception("Creating an questions collection failed on save.");
            }

            return Ok();
        }

        [HttpGet("GetQuestionCollection", Name = "GetQuestionCollection")]
        public IActionResult GetQuestionCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {           
            if (ids == null)
            {
                return BadRequest();
            }

            var questionEntities = _quizRepository.GetQuestionsWithListOfId(ids);

            if (ids.Count() != questionEntities.Count())
            {
                return NotFound();
            }

            var questionsToReturn = Mapper.Map<IEnumerable<QuestionDto>>(questionEntities);
            return Ok(questionsToReturn);
        }
    }
}
