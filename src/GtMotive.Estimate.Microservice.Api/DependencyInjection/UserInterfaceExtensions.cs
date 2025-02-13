using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListActiveRentalsUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehiclesUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<WebApiPresenter>();
            services.AddScoped<IWebApiPresenter>(sp => sp.GetRequiredService<WebApiPresenter>());
            services.AddScoped<IOutputPortStandard<AddVehicleUseCaseOutput>>(sp => sp.GetRequiredService<WebApiPresenter>());
            services.AddScoped<IOutputPortStandard<ListAvailableVehiclesUseCaseOutput>>(sp => sp.GetRequiredService<WebApiPresenter>());
            services.AddScoped<IOutputPortStandard<RentVehicleUseCaseOutput>>(sp => sp.GetRequiredService<WebApiPresenter>());
            services.AddScoped<IOutputPortStandard<ReturnVehicleUseCaseOutput>>(sp => sp.GetRequiredService<WebApiPresenter>());
            services.AddScoped<IOutputPortStandard<ListActiveRentalsUseCaseOutput>>(sp => sp.GetRequiredService<WebApiPresenter>());
            services.AddScoped<IOutputPortNotFound>(sp => sp.GetRequiredService<WebApiPresenter>());
            return services;
        }
    }
}
