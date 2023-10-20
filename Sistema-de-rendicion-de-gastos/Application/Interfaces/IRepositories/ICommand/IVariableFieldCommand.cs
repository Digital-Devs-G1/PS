using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories.ICommand
{
    public interface IVariableFieldCommand : IGenericRepositoryCommand<VariableField>
    {
        public Report GetReport(int idReport);

        Task<bool> ExistReportById (int id);

    }
}
