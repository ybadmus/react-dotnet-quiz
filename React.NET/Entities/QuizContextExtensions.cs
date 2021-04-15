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

            context.PossibleAnswers.RemoveRange(context.PossibleAnswers);
            context.SaveChanges();

            var possibleAnswers = new List<PossibleAnswer>()
            {
                new PossibleAnswer()
                {
                    Id = new Guid("ac12c0f8-9c84-43a2-90d4-9707fe94f9bd"),
                    QuestionId = new Guid("7874b9ca-f1d9-410c-807f-4a957a160e34"),
                    PossibleAnswerText = "1957"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("94bf7c95-e6bf-482b-95af-ec803414dce4"),
                    QuestionId = new Guid("7874b9ca-f1d9-410c-807f-4a957a160e34"),
                    PossibleAnswerText = "2020"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("68474235-1154-4433-b6b3-878d2bfdbdd1"),
                    QuestionId = new Guid("7874b9ca-f1d9-410c-807f-4a957a160e34"),
                    PossibleAnswerText = "1864"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("74a5effa-2d33-412a-add7-425b775c476c"),
                    QuestionId = new Guid("7874b9ca-f1d9-410c-807f-4a957a160e34"),
                    PossibleAnswerText = "1900"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("24003361-81f3-4596-95eb-8514eb8e8ee7"),
                    QuestionId = new Guid("f9d07161-91ad-4794-8633-e98dc0d5b264"),
                    PossibleAnswerText = "George Bush"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("be86b111-a6ac-4e26-9a76-16c002335b90"),
                    QuestionId = new Guid("f9d07161-91ad-4794-8633-e98dc0d5b264"),
                    PossibleAnswerText = "Kwame Nkrumah"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("21f97212-0eb0-4cf0-97fd-a9a11c36985f"),
                    QuestionId = new Guid("f9d07161-91ad-4794-8633-e98dc0d5b264"),
                    PossibleAnswerText = "Atta Mills"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("2340d8f6-71a6-4ea5-adff-6219cec7f9bc"),
                    QuestionId = new Guid("43c0cd83-c4fe-43fd-9106-222be781bfbd"),
                    PossibleAnswerText = "Cape Coast"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("d98ca390-c4a3-41d8-aafa-dbe91e342d3a"),
                    QuestionId = new Guid("43c0cd83-c4fe-43fd-9106-222be781bfbd"),
                    PossibleAnswerText = "Kumasi"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("71e8ddff-de04-423d-a17a-ea7505a34b32"),
                    QuestionId = new Guid("43c0cd83-c4fe-43fd-9106-222be781bfbd"),
                    PossibleAnswerText = "Tema"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("81a7d813-12b8-455e-8c51-f2a82b91d89b"),
                    QuestionId = new Guid("43c0cd83-c4fe-43fd-9106-222be781bfbd"),
                    PossibleAnswerText = "Accra"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("5770bed5-ff25-472f-b7b3-0d4d76352de6"),
                    QuestionId = new Guid("bd611088-aebe-4542-8ac3-3d932fdb84fd"),
                    PossibleAnswerText = "true"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("7f298544-6729-4aac-babf-26dc0867dd3c"),
                    QuestionId = new Guid("bd611088-aebe-4542-8ac3-3d932fdb84fd"),
                    PossibleAnswerText = "false"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("4c748ed7-b51a-426c-91b2-75e631c2a743"),
                    QuestionId = new Guid("bdbf0713-8cf1-45f1-8d7b-b8f212475d0a"),
                    PossibleAnswerText = "Einar Gerhardsen"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("75e56d11-a476-43f4-a18d-5cbec5280db3"),
                    QuestionId = new Guid("bdbf0713-8cf1-45f1-8d7b-b8f212475d0a"),
                    PossibleAnswerText = "Jens Stoltenberg"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("44734b78-d257-4d83-a436-26813b96e6f0"),
                    QuestionId = new Guid("bdbf0713-8cf1-45f1-8d7b-b8f212475d0a"),
                    PossibleAnswerText = "Johan Nygaardsvold"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("dd67c8d8-edf1-4014-b6c1-61df10030961"),
                    QuestionId = new Guid("17c010f6-f8f8-4055-b67c-252bbd5084f5"),
                    PossibleAnswerText = "California"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("3175b2ba-1655-4033-a65e-212a9dff88fb"),
                    QuestionId = new Guid("17c010f6-f8f8-4055-b67c-252bbd5084f5"),
                    PossibleAnswerText = "Stavanger"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("286e497d-c4d1-4ac9-a3eb-75c68a565853"),
                    QuestionId = new Guid("17c010f6-f8f8-4055-b67c-252bbd5084f5"),
                    PossibleAnswerText = "Bergen"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("f22fcbf5-db54-4f40-919a-3d625f271091"),
                    QuestionId = new Guid("17c010f6-f8f8-4055-b67c-252bbd5084f5"),
                    PossibleAnswerText = "Oslo"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("f17bfd85-0436-48aa-aebc-cdbd150a916b"),
                    QuestionId = new Guid("304f39cd-5793-4bca-bb99-495a0380cb32"),
                    PossibleAnswerText = "true"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("f717ce95-b40c-4c1e-bf95-0138894d417f"),
                    QuestionId = new Guid("304f39cd-5793-4bca-bb99-495a0380cb32"),
                    PossibleAnswerText = "false"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("e1d42615-c4cf-454f-a8d0-16c93483d7fd"),
                    QuestionId = new Guid("d775e3fa-d4d7-40fc-aca4-1a7d225b31ed"),
                    PossibleAnswerText = "true"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("bf93ce59-0368-4eff-b9a6-d6acb0bc9268"),
                    QuestionId = new Guid("d775e3fa-d4d7-40fc-aca4-1a7d225b31ed"),
                    PossibleAnswerText = "false"
                },

                new PossibleAnswer()
                {
                    Id = new Guid("9ba05e43-7968-4bb7-9deb-c17261435210"),
                    QuestionId = new Guid("a26768cc-d891-485b-979c-f03eccbb5606"),
                    PossibleAnswerText = "Lagos"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("17e8e65a-5672-4122-b956-82259431285f"),
                    QuestionId = new Guid("a26768cc-d891-485b-979c-f03eccbb5606"),
                    PossibleAnswerText = "Kumasi"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("43022225-c629-4980-ac86-f910d271067c"),
                    QuestionId = new Guid("a26768cc-d891-485b-979c-f03eccbb5606"),
                    PossibleAnswerText = "Tema"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("ee48c9dc-5e11-47f9-b85b-6422cbf4a9db"),
                    QuestionId = new Guid("a26768cc-d891-485b-979c-f03eccbb5606"),
                    PossibleAnswerText = "Cape Town"
                },
                
                new PossibleAnswer()
                {
                    Id = new Guid("bf505517-f85d-4898-b311-04df621b3866"),
                    QuestionId = new Guid("813cbc9f-61bc-4dd7-b359-73ef5adcef6c"),
                    PossibleAnswerText = "Lagos"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("a4247f34-2ab9-499b-a75e-1f904f7182b6"),
                    QuestionId = new Guid("813cbc9f-61bc-4dd7-b359-73ef5adcef6c"),
                    PossibleAnswerText = "Kumasi"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("7ddb66d5-628b-4bbb-9e2a-ee280e2300a5"),
                    QuestionId = new Guid("813cbc9f-61bc-4dd7-b359-73ef5adcef6c"),
                    PossibleAnswerText = "Tema"
                },
                new PossibleAnswer()
                {
                    Id = new Guid("2acfa935-a096-43f5-909e-00819171a773"),
                    QuestionId = new Guid("813cbc9f-61bc-4dd7-b359-73ef5adcef6c"),
                    PossibleAnswerText = "Cape Town"
                }
            };
        }
    }
}
