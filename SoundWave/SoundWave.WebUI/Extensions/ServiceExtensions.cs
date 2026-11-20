using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SoundWave.Business.Mappings;
using SoundWave.Business.Options;
using SoundWave.Business.Services.Abstract;
using SoundWave.Business.Services.Concrete;
using SoundWave.DataAccess.Context;
using SoundWave.DataAccess.Repositories.Albums;
using SoundWave.DataAccess.Repositories.Artists;
using SoundWave.DataAccess.Repositories.Songs;
using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;
using System.Security.Claims;
using System.Text;

namespace SoundWave.WebUI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<ISongRepository,  SongRepository>();
        }

        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

            }).AddEntityFrameworkStores<AppDbContext>();
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                    ClockSkew = TimeSpan.Zero,
                    RoleClaimType = ClaimTypes.Role
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var token = context.Request.Cookies["access_token"];
                        if (!string.IsNullOrEmpty(token))
                        {
                            context.Token = token;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanListenFree", policy =>
                {
                    policy.RequireRole(SubscriptionLevel.Free.ToString(), SubscriptionLevel.Standard.ToString(), SubscriptionLevel.Premium.ToString(), SubscriptionLevel.Diamond.ToString());
                });

                options.AddPolicy("CanListenStandard", policy =>
                {
                    policy.RequireRole(SubscriptionLevel.Standard.ToString(), SubscriptionLevel.Premium.ToString(), SubscriptionLevel.Diamond.ToString());
                });

                options.AddPolicy("CanListenPremium", policy =>
                {
                    policy.RequireRole(SubscriptionLevel.Premium.ToString(), SubscriptionLevel.Diamond.ToString());
                });

                options.AddPolicy("CanListenDiamond", policy =>
                {
                    policy.RequireRole(SubscriptionLevel.Diamond.ToString());
                });
            });
        }
    }
}
