using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.API.Database;
using CQRS.API.Domain;
using MediatR;

namespace CQRS.API.Commands
{
    public static class AddTodo
    {
        /// <summary>
        /// Command
        /// </summary>
        /// <param name="Name"></param>
        public record Command(string Name) : IRequest<int>;
        
        /// <summary>
        /// Handler
        /// </summary>
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly Repository _repository;
            
            public Handler(Repository repository)
            {
                _repository = repository;
            }
            
            /// <summary>
            /// Handle
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var id = _repository.Todos.LastOrDefault()!.Id + 1;
                
                _repository.Todos.Add(new Todo { Id = id, Name = request.Name, Completed = false });

                return await Task.FromResult(id);
            }
        }
    }
}