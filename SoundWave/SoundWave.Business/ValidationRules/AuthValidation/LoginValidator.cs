using FluentValidation;
using SoundWave.DTO.AuthDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.ValidationRules.AuthValidation
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .NotEmpty().WithMessage("Kullanıcı adı veya e-posta alanı boş geçilemez.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
        }
    }
}
