using FluentValidation;
using SoundWave.DTO.AuthDtos;

namespace SoundWave.Business.ValidationRules.AuthValidation
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad ve soyad kısmı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad ve soyad kısmı minimum 3 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("Ad ve soyad kısmı maksimum 50 karakterden oluşmalıdır.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı kısmı boş geçilemez.")
                .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş geçilemez.")
                .EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş geçilemez.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches("[a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter (.,!@#$ vb.) içermelidir.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez.")
                .Equal(x => x.Password).WithMessage("Girilen şifreler birbiriyle uyuşmuyor.");


        }
    }
}
