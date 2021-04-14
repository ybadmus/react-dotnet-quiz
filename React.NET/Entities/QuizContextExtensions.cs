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
                new Question()
                {
                    Id = new Guid("7874b9ca-f1d9-410c-807f-4a957a160e34"),
                    QuestionText = "When did Ghana gain Independence",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("fd4d86aa-deb0-463e-8db5-a79132f585c9"),
                            AnswerText = "1957"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("f9d07161-91ad-4794-8633-e98dc0d5b264"),
                    QuestionText = "Who was the first president of Ghana",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("65d4c962-4d45-4035-9e7f-1b0edaeada7c"),
                            AnswerText = "Kwame Nkrumah"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("43c0cd83-c4fe-43fd-9106-222be781bfbd"),
                    QuestionText = "What is the capital city of Ghana",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("117d9f62-de59-413d-b5d3-0f360d49f16f"),
                            AnswerText = "Accra"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("bd611088-aebe-4542-8ac3-3d932fdb84fd"),
                    QuestionText = "Nana Akuffo Addo is the president of America",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("1b236476-21aa-42e6-b530-3d42ba0afffa"),
                            AnswerText = "false"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("bdbf0713-8cf1-45f1-8d7b-b8f212475d0a"),
                    QuestionText = "Who is the longest serving prime minister of Norway",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("f30220e4-ab92-4b10-ba5a-ba34426def82"),
                            AnswerText = "Einar Gerhardsen"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("17c010f6-f8f8-4055-b67c-252bbd5084f5"),
                    QuestionText = "Which of them are cities in Norway",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("1ba8e510-4f43-42e8-889e-ccd2f9fdfeb2"),
                            AnswerText = "Oslo"
                        },
                        new Answer()
                        {
                            Id = new Guid("d7a306cd-fab1-41dd-8366-5314aa878911"),
                            AnswerText = "Bergen"
                        },
                        new Answer()
                        {
                            Id = new Guid("1e7e9f54-be5e-4e1a-bc6e-faa60a980bca"),
                            AnswerText = "Stavanger"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("304f39cd-5793-4bca-bb99-495a0380cb32"),
                    QuestionText = "The head office of Lifekey is in Bergen, Norway",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("66ca52fb-9c33-4146-b542-c985bd6a6e75"),
                            AnswerText = "true"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("d775e3fa-d4d7-40fc-aca4-1a7d225b31ed"),
                    QuestionText = "Erna Solberg is the president of Norway",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("cab13e9f-3341-497c-88d5-23c907787629"),
                            AnswerText = "true"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("a26768cc-d891-485b-979c-f03eccbb5606"),
                    QuestionText = "Which of them are cities in Ghana",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("98ca2a5d-b7ec-4332-8e23-281537334851"),
                            AnswerText = "Tema"
                        },
                        new Answer()
                        {
                            Id = new Guid("ce037ab0-ca07-4312-a227-a8b2a162bce7"),
                            AnswerText = "Kumasi"
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("813cbc9f-61bc-4dd7-b359-73ef5adcef6c"),
                    QuestionText = "Which of the tools were used in building this app",
                    Answers = new List<Answer>()
                    {
                        new Answer()
                        {
                            Id = new Guid("7b46c293-e8a8-4885-b251-4f3cdcb0bac8"),
                            AnswerText = ".NET Core"
                        },
                        new Answer()
                        {
                            Id = new Guid("07fe2805-85fb-4284-9c86-a4e609a07b51"),
                            AnswerText = "C#"
                        },
                        new Answer()
                        {
                            Id = new Guid("056693a3-ecf3-4ce1-8e3e-ba82940eaaea"),
                            AnswerText = "React"
                        },
                        new Answer()
                        {
                            Id = new Guid("b5ca22a0-2229-4f55-9e6b-91d613c0db5a"),
                            AnswerText = "Postgres"
                        }
                    }
                }
            };

            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
