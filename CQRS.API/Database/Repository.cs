using System.Collections.Generic;
using CQRS.API.Domain;

namespace CQRS.API.Database
{
    public class Repository
    {
        public List<Todo> Todos { get; } = new()
        {
            new Todo { Id = 1, Name = "Learn Cqrs", Completed = false },
            new Todo { Id = 2, Name = "Learn CircleCI", Completed = false },
            new Todo { Id = 3, Name = "Setup Sql Server on Mac with Docker", Completed = true },
            new Todo { Id = 4, Name = "Restore Sql database", Completed = true }
        };
    }
}