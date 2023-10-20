using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using FluentValidation;

namespace Application.Validations
{
    public class DepartamentTemplateValidation : AbstractValidator<DepartmentTemplateResponse>
    {
        public readonly IDepartmentTemplateQuery _queryDept;
        public DepartamentTemplateValidation(IDepartmentTemplateQuery queryDept) 
        {
            _queryDept = queryDept;

            // NO HACE FALTA PARA UN DTORequest
            //RuleFor(dt => dt.DepartmentTemplateId)
            //       .NotNull()
            //       .NotEmpty();
            RuleFor(dt => dt.DeptartmentId)
                   .NotNull()
                   .NotEmpty();
            RuleFor(dt => dt.DepartmentTemplateName)
                   .NotNull()
                   .MaximumLength(30)
                   .NotEmpty();

            RuleFor(dt => dt.DeptartmentId)
                   .Must(id => DepartamentExistById(id));
        }

        private bool DepartamentExistById(int id)
        {
            return _queryDept.ExistDepartamentId(id).Result;
        }
    }
}
