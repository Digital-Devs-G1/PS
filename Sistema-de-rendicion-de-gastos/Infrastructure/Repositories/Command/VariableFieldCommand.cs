using Application.Dto.Response.StatusResponseNS;
using Application.Interfaces.IRepositories.ICommand;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Command
{
    public class VariableFieldCommand 
        : GenericCommand<VariableField>
        , IVariableFieldCommand
    {
        public VariableFieldCommand(
            ReportsDbContext context
            )//IRepositoryResponseFactory responseFactory) 
            : 
            base(context/*, responseFactory*/)
        {
        }

        public Task<bool> ExistReportById(int id)
        {
            throw new NotImplementedException();
        }

        public Report GetReport(int idReport)
        {
            throw new NotImplementedException();
        }
    }
}