using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using React.NET.Entities;
using React.NET.Helpers;
using React.NET.Models;
using React.NET.Services;

namespace React.NET.Controllers
{
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private IQuizRepository _quizRepository;
        private IUrlHelper _urlHelper;

        public QuestionsController(IQuizRepository quizRepository, IUrlHelper urlHelper)
        {
            _quizRepository = quizRepository;
            _urlHelper = urlHelper;
        }

        [HttpGet("GetQuestions", Name = "GetQuestions")]
        public IActionResult GetQuestions(QuestionsResourceParameters questionsResourceParameters)
        {
            var questionsFromRepo = _quizRepository.GetQuestions(questionsResourceParameters);

            var previousPageLink = questionsFromRepo.HasPrevious ?
                    CreateQuestionsResourceUri(questionsResourceParameters,
                    ResourceUriType.PreviousPage) : null;

            var nextPageLink = questionsFromRepo.HasNext ?
                CreateQuestionsResourceUri(questionsResourceParameters,
                ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = questionsFromRepo.TotalCount,
                pageSize = questionsFromRepo.PageSize,
                currentPage = questionsFromRepo.CurrentPage,
                totalPages = questionsFromRepo.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("X-Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            var questions = Mapper.Map<IEnumerable<QuestionDto>>(questionsFromRepo);
            return Ok(questions);
        }

        private string CreateQuestionsResourceUri(
            QuestionsResourceParameters questionsResourceParameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetAllQuestions",
                      new
                      {
                          searchQuery = questionsResourceParameters.SearchQuery,
                          pageNumber = questionsResourceParameters.PageNumber - 1,
                          pageSize = questionsResourceParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetAllQuestions",
                      new
                      {
                          searchQuery = questionsResourceParameters.SearchQuery,
                          pageNumber = questionsResourceParameters.PageNumber + 1,
                          pageSize = questionsResourceParameters.PageSize
                      });

                default:
                    return _urlHelper.Link("GetAllQuestions",
                    new
                    {
                        searchQuery = questionsResourceParameters.SearchQuery,
                        pageNumber = questionsResourceParameters.PageNumber,
                        pageSize = questionsResourceParameters.PageSize
                    });
            }
        }

        [HttpGet("GetQuestion", Name = "GetQuestion")]
        public IActionResult GetQuestion([FromQuery] Guid id)
        {
            var questionFromRepo = _quizRepository.GetQuestion(id);

            if (questionFromRepo == null)
            {
                return NotFound();
            }

            var question = Mapper.Map<QuestionDto>(questionFromRepo);
            return Ok(question);
        }

        [HttpPost("CreateQuestion", Name = "CreateQuestion")]
        public IActionResult CreateQuestion([FromBody] QuestionForCreationDto question)
        {
            if (question == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResultTunsBad(ModelState);
            }

            var questionEntity = Mapper.Map<Question>(question);

            _quizRepository.AddQuestion(questionEntity);

            if (!_quizRepository.Save())
            {
                throw new Exception("Creating an question failed on save.");
            }

            var questionToReturn = Mapper.Map<QuestionDto>(questionEntity);

            return CreatedAtRoute("CreateQuestion",
                new { id = questionToReturn.Id },
                questionToReturn);
        }

        [HttpGet("CheckIfQuestionExists", Name = "CheckIfQuestionExists")]
        public IActionResult CheckIfQuestionExists([FromQuery] Guid id)
        {
            var results = _quizRepository.QuestionExists(id);
            if (results)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            return NotFound();
        }

        [HttpDelete("DeleteQuestion", Name = "DeleteQuestion")]
        public IActionResult DeleteQuestion(Guid id)
        {
            var questionFromRepo = _quizRepository.GetQuestion(id);
            if (questionFromRepo == null)
            {
                return NotFound();
            }

            _quizRepository.DeleteQuestion(questionFromRepo);

            if (!_quizRepository.Save())
            {
                throw new Exception($"Deleting question {id} failed on save.");
            }

            return NoContent();
        }

    }
}
