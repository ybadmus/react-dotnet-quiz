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
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("ac12c0f8-9c84-43a2-90d4-9707fe94f9bd"),
                            PossibleAnswerText = "1957",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("94bf7c95-e6bf-482b-95af-ec803414dce4"),
                            PossibleAnswerText = "2020",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("68474235-1154-4433-b6b3-878d2bfdbdd1"),
                            PossibleAnswerText = "1864",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("74a5effa-2d33-412a-add7-425b775c476c"),
                            PossibleAnswerText = "1900",
                            Answer = false
                        }
                    }
                },
                new Question()
                {
                    Id = new Guid("f9d07161-91ad-4794-8633-e98dc0d5b264"),
                    QuestionText = "Who was the first president of Ghana",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("24003361-81f3-4596-95eb-8514eb8e8ee7"),
                            PossibleAnswerText = "George Bush",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("be86b111-a6ac-4e26-9a76-16c002335b90"),
                            PossibleAnswerText = "Kwame Nkrumah",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("21f97212-0eb0-4cf0-97fd-a9a11c36985f"),
                            PossibleAnswerText = "Atta Mills",
                            Answer = false
                        },
                    },

                },
                new Question()
                {
                    Id = new Guid("43c0cd83-c4fe-43fd-9106-222be781bfbd"),
                    QuestionText = "What is the capital city of Ghana",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("2340d8f6-71a6-4ea5-adff-6219cec7f9bc"),
                            PossibleAnswerText = "Cape Coast",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("d98ca390-c4a3-41d8-aafa-dbe91e342d3a"),
                            PossibleAnswerText = "Kumasi",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("71e8ddff-de04-423d-a17a-ea7505a34b32"),
                            PossibleAnswerText = "Tema",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("81a7d813-12b8-455e-8c51-f2a82b91d89b"),
                            PossibleAnswerText = "Accra",
                            Answer = true
                        },
                    },
                },
                new Question()
                {
                    Id = new Guid("bd611088-aebe-4542-8ac3-3d932fdb84fd"),
                    QuestionText = "Nana Akuffo Addo is the president of America",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("5770bed5-ff25-472f-b7b3-0d4d76352de6"),
                            PossibleAnswerText = "true",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("7f298544-6729-4aac-babf-26dc0867dd3c"),
                            PossibleAnswerText = "false",
                            Answer = false
                        },
                    }
                },
                new Question()
                {
                    Id = new Guid("bdbf0713-8cf1-45f1-8d7b-b8f212475d0a"),
                    QuestionText = "Who is the longest serving prime minister of Norway",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("4c748ed7-b51a-426c-91b2-75e631c2a743"),
                            PossibleAnswerText = "Einar Gerhardsen",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("75e56d11-a476-43f4-a18d-5cbec5280db3"),
                            PossibleAnswerText = "Jens Stoltenberg",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("44734b78-d257-4d83-a436-26813b96e6f0"),
                            PossibleAnswerText = "Johan Nygaardsvold",
                            Answer = false
                        },
                    },
                },

                new Question()
                {
                    Id = new Guid("17c010f6-f8f8-4055-b67c-252bbd5084f5"),
                    QuestionText = "Which of them are cities in Norway",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("dd67c8d8-edf1-4014-b6c1-61df10030961"),
                            PossibleAnswerText = "California",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("3175b2ba-1655-4033-a65e-212a9dff88fb"),
                            PossibleAnswerText = "Stavanger",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("286e497d-c4d1-4ac9-a3eb-75c68a565853"),
                            PossibleAnswerText = "Bergen",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("f22fcbf5-db54-4f40-919a-3d625f271091"),
                            PossibleAnswerText = "Oslo",
                            Answer = true
                        },
                    }
                },
                new Question()
                {
                    Id = new Guid("304f39cd-5793-4bca-bb99-495a0380cb32"),
                    QuestionText = "The head office of Lifekey is in Bergen, Norway",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("f17bfd85-0436-48aa-aebc-cdbd150a916b"),
                            PossibleAnswerText = "true",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("f717ce95-b40c-4c1e-bf95-0138894d417f"),
                            PossibleAnswerText = "false",
                            Answer = false
                        },
                    }
                },
                new Question()
                {
                    Id = new Guid("d775e3fa-d4d7-40fc-aca4-1a7d225b31ed"),
                    QuestionText = "Erna Solberg is the president of Norway",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("e1d42615-c4cf-454f-a8d0-16c93483d7fd"),
                            PossibleAnswerText = "true",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("bf93ce59-0368-4eff-b9a6-d6acb0bc9268"),
                            PossibleAnswerText = "false",
                            Answer = false
                        },
                    }
                },
                new Question()
                {
                    Id = new Guid("a26768cc-d891-485b-979c-f03eccbb5606"),
                    QuestionText = "Which of them are cities in Ghana",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("9ba05e43-7968-4bb7-9deb-c17261435210"),
                            PossibleAnswerText = "Lagos",
                            Answer = false
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("17e8e65a-5672-4122-b956-82259431285f"),
                            PossibleAnswerText = "Kumasi",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("43022225-c629-4980-ac86-f910d271067c"),
                            PossibleAnswerText = "Tema",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("ee48c9dc-5e11-47f9-b85b-6422cbf4a9db"),
                            PossibleAnswerText = "Cape Town",
                            Answer = false
                        },
                    }
                },
                new Question()
                {
                    Id = new Guid("813cbc9f-61bc-4dd7-b359-73ef5adcef6c"),
                    QuestionText = "Which of the tools were used in building this app",
                    PossibleAnswers = new List<PossibleAnswer>()
                    {
                        new PossibleAnswer()
                        {
                            Id = new Guid("bf505517-f85d-4898-b311-04df621b3866"),
                            PossibleAnswerText = ".NET Core",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("a4247f34-2ab9-499b-a75e-1f904f7182b6"),
                            PossibleAnswerText = "C#",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("7ddb66d5-628b-4bbb-9e2a-ee280e2300a5"),
                            PossibleAnswerText = "React",
                            Answer = true
                        },
                        new PossibleAnswer()
                        {
                            Id = new Guid("2acfa935-a096-43f5-909e-00819171a773"),
                            PossibleAnswerText = "Postgres",
                            Answer = true
                        }
                    }
                }
            };

            context.Questions.AddRange(questions);
            context.SaveChanges();
        }
    }
}
