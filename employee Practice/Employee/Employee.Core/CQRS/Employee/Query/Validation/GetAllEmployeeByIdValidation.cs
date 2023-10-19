using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.CQRS.Employee.Query.Validation;

public class GetAllEmployeeByIdValidation:AbstractValidator<GetAllEmployeeByIdQuery>
{
    public GetAllEmployeeByIdValidation()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Requried");
    }
}
