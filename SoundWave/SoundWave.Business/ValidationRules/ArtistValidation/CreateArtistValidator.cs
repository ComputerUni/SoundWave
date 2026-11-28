using FluentValidation;
using SoundWave.DTO.ArtistDtos;

namespace SoundWave.Business.ValidationRules.ArtistValidation
{
    public class CreateArtistValidator : AbstractValidator<CreateArtistDto>
    {
        public CreateArtistValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şarkıcının ismi boş geçilemez.")
                .MinimumLength(3).WithMessage("Şarkıcı ismi en az 3 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("Şarkıcı ismi en fazla 50 karakterden oluşmalıdır.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Şarkıcı resim linki boş geçilemez");

            RuleFor(x => x.Bio).NotEmpty().WithMessage("Şarkıcı hakkında bölümü boş geçilemez")
                .MinimumLength(3).WithMessage("Şarkıcı hakkında bölümüm en az 3 karakterden oluşmalıdır.")
                .MaximumLength(300).WithMessage("Şarkıcı hakkında bölümüm en fazla 300 karakterden oluşmalıdır.");
        }
    }
}
