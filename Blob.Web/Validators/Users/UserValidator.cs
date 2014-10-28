using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Blob.Web.Models.Users;

namespace Blob.Web.Validators.Users
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            //I've ignored localisation for the sake of quick completeness
            RuleFor(x => x.fname).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
        }
    }
}