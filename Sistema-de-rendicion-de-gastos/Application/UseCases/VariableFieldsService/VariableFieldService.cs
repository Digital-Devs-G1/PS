using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IServices.IVariableFields;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.VariableFieldsService
{
    public class VariableFieldService : IVariableFieldService
    {
        private readonly IGenericCommand<VariableField> variableFieldCommand;

        public VariableFieldService(IGenericCommand<VariableField> repository)
        {
            variableFieldCommand = repository;
        }

        public async Task<bool> AddFields(IList<VariableField> fields)
        {
            return default;// await variableFieldCommand.AddAndCommit(fields);
        }
    }
}






