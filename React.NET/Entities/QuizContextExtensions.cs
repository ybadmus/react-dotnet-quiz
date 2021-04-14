using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Entities
{
    public static class QuizContextExtensions
    {
        public static void EnsureSeedDataForContext(this QuizContext context)
        {
            context.Questions.RemoveRange(context.Questions);
            context.SaveChanges();

            var questions = new List<Question>()
            {

            };

            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
