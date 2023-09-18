using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class VariableFieldService : IVariableFieldService
    {
        private readonly IGenericRepositoryCommand<VariableField> variableFieldCommand;

        public VariableFieldService(IGenericRepositoryCommand<VariableField> repository)
        {
            variableFieldCommand = repository;
        }

        public async Task<bool> AddFields(IList<VariableField> fields)
        {
            return await variableFieldCommand.Add(fields);
        }
    }
}
