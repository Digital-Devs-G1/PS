using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IServices.IVariableFields;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.VariableFields
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
