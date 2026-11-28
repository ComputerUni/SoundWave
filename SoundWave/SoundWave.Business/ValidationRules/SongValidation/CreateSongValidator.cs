using FluentValidation;
using SoundWave.DTO.SongDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.ValidationRules.SongValidation
{
    public class CreateSongValidator : AbstractValidator<CreateSongDto>
    {
        public CreateSongValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Şarkı başlığı boş geçilemez.")
                .MinimumLength(3).WithMessage("Şarkı başlığı en az 3 karakterden oluşmalıdır.")
                .MaximumLength(100).WithMessage("Şarkı başlığı en fazla 100 karakterden oluşmalıdır.");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("Şarkı süresi boş geçilemez.")
                .GreaterThan(TimeSpan.Zero).WithMessage("Şarkı süresi 0 saniyeden büyük olmalıdır.")
                .LessThanOrEqualTo(TimeSpan.FromMinutes(5)).WithMessage("Şarkı süresi en fazla 5 dakika olabilir.");

            RuleFor(x => x.AudioUrl)
                .NotEmpty().WithMessage("Ses dosyası veya URL alanı boş geçilemez.");

            RuleFor(x => x.SubscriptionLevel)
                .IsInEnum().WithMessage("Lütfen geçerli bir abonelik seviyesi seçiniz.");

            RuleFor(x => x.AlbumId)
                .GreaterThan(0).WithMessage("Lütfen geçerli bir albüm seçiniz.");
               
        }
    }
}
