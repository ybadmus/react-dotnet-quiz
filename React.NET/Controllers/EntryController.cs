using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using React.NET.Entities;
using React.NET.Models;
using React.NET.Services;

namespace React.NET.Controllers
{
    [Route("api/Entry")]
    public class EntryController : Controller
    {
        private IQuizRepository _quizRepository;
        public EntryController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpPost("SaveEntry", Name = "SaveEntry")]
        public IActionResult SaveEntry([FromBody]UserSelectionsForCreationDto entry)
        {
            bool resp = _quizRepository.SaveEntryForQuestion(entry);

            if (!_quizRepository.Save())
            {
                throw new Exception($"Creating entry failed on save.");
            }

            return Ok(resp);
        }
    }
}
