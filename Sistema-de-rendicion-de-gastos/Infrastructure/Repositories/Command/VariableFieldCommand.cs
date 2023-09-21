using Application.Interfaces.IRepositories.ICommand;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Command
{
    public class VariableFieldCommand 
        : GenericRepositoryCommand<VariableField>
        , IVariableFieldCommand
    {
        public VariableFieldCommand(ReportsDbContext context) : base(context)
        {
        }
    }
}
