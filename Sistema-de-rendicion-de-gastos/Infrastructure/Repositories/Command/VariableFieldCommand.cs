using Application.Dto.Response.StatusResponseNS;
using Application.Interfaces.IRepositories.ICommand;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Command
{
    public class VariableFieldCommand 
        : GenericRepositoryCommand<VariableField>
        , IVariableFieldCommand
    {
        public VariableFieldCommand(
            ReportsDbContext context,
            IRepositoryResponseFactory responseFactory) 
            : 
            base(context, responseFactory)
        {
        }
    }
}