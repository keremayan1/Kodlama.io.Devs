using Application.Features.Developers.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<DeveloperBusinessRules>();

            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
               
        }
    }
}
