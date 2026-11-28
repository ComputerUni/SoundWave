using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SoundWave.Business.ValidationRules.AlbumValidation;
using SoundWave.Business.ValidationRules.ArtistValidation;
using SoundWave.Business.ValidationRules.AuthValidation;
using SoundWave.Business.ValidationRules.SongValidation;

namespace SoundWave.WebUI.Extensions
{
    public static class ValidationExtensions
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateArtistValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateArtistValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateAlbumValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateAlbumValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateSongValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateSongValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
        }

        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach(var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
