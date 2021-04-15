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
    public class EntryController : Controller
    {
        private IQuizRepository _quizRepository;
        public EntryController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpPost("SaveEntry", Name = "SaveEntry")]
        public IActionResult SaveEntry([FromBody]EntryForCreationDto entry)
        {
            var repoEntry = Mapper.Map<Entry>(entry);

            _quizRepository.SaveEntryForQuestion(repoEntry);

            if (!_quizRepository.Save())
            {
                throw new Exception($"Creating entry failed on save.");
            }

            return Ok();
        }
    }
}
