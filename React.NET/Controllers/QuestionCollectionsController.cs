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

        [HttpPost("CreateAuthorCollection", Name = "CreateAuthorCollection")]
        public IActionResult CreateAuthorCollection([FromBody] IEnumerable<QuestionForCreationDto> questionCollection)
        {
            if (questionCollection == null)
            {
                return BadRequest();
            }

            var authorEntities = Mapper.Map<IEnumerable<Question>>(questionCollection);

            foreach (var author in authorEntities)
            {
                _quizRepository.AddQuestion(author);
            }

            if (!_quizRepository.Save())
            {
                throw new Exception("Creating an author collection failed on save.");
            }

            return Ok();
        }

        [HttpGet("GetAuthorCollection", Name = "GetAuthorCollection")]
        public IActionResult GetAuthorCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
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

            var authorsToReturn = Mapper.Map<IEnumerable<QuestionDto>>(questionEntities);
            return Ok(authorsToReturn);
        }
    }
}
