using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Common.Behaviors;

namespace Shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
