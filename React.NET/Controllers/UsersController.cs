﻿using System;
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
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private IQuizRepository _quizRepository;
        public UsersController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [HttpPost("CreateUser", Name = "CreateUser")]
        public IActionResult CreateUser([FromBody] UserForCreationDto username)
        {
            var repoUser = Mapper.Map<User>(username);

            _quizRepository.CreateUser(repoUser);

            if (!_quizRepository.Save())
            {
                throw new Exception($"Creating user failed on save.");
            }

            return Ok();
        }
    }
}
