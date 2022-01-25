using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRS.API.Database;
using MediatR;

namespace CQRS.API.Queries
{
    public static class GetTodoById
    {
        /// <summary>
        /// Query / Command
        /// </summary>
        /// <param name="Id"></param>
        public record Query(int Id) : IRequest<Response>;

        /// <summary>
        /// Handler
        /// </summary>
        public class Handler : IRequestHandler<Query, Response>
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
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                // Business logic
                var todo = _repository.Todos.FirstOrDefault(x => x.Id == request.Id);
                return await Task.FromResult(todo == null ? null : new Response(todo.Id, todo.Name, todo.Completed));
            }
        }

        /// <summary>
        /// Response
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Completed"></param>
        public record Response(int Id, string Name, bool Completed);
    }
}