using Application.DTO.Response;
using Application.DTO.Response.ReportNS;
using Application.Interfaces.IServices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class VariableFieldValidator : AbstractValidator<VariableFieldResponse>
    {
        public VariableFieldValidator() 
        {
            RuleFor(vfr => vfr.Label).MaximumLength(20).WithMessage("El máximo permitido es de 20 caracteres")
                                     .NotEmpty().WithMessage("El campo no puede ser vacio");
            RuleFor(vfr => vfr.Value).NotEmpty().WithMessage("El campo no puede ser vacio")
                                     .NotNull()
                                     .MaximumLength(50).WithMessage("El máximo permitido es de 50 caracteres");
            RuleFor(vfr => vfr.DataType).NotEmpty().WithMessage("El campo no puede ser vacio")
                                        .NotNull()
                                        .GreaterThan(0).WithMessage("Debe ser un entero positivo mayor a 0");
        }
    }
}
