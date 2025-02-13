using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListActiveRentalsUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehiclesUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUseCase<AddVehicleUseCaseInput>, AddVehicleUseCase>();
            services.AddScoped<IUseCase<ListAvailableVehiclesUseCaseInput>, ListAvailableVehiclesUseCase>();
            services.AddScoped<IUseCase<RentVehicleUseCaseInput>, RentVehicleUseCase>();
            services.AddScoped<IUseCase<ReturnVehicleUseCaseInput>, ReturnVehicleUseCase>();
            services.AddScoped<IUseCase<ListActiveRentalsUseCaseInput>, ListActiveRentalsUseCase>();
            services.AddScoped<IOutputPortStandard<AddVehicleUseCaseOutput>, AddVehicleOutputPort>();
            services.AddScoped<IOutputPortStandard<ListAvailableVehiclesUseCaseOutput>, ListAvailableVehiclesOutputPort>();
            services.AddScoped<IOutputPortStandard<RentVehicleUseCaseOutput>, RentVehicleOutputPort>();
            services.AddScoped<IOutputPortStandard<ReturnVehicleUseCaseOutput>, ReturnVehicleOutputPort>();
            services.AddScoped<IOutputPortStandard<ListActiveRentalsUseCaseOutput>, ListActiveRentalsOutputPort>();
            services.AddScoped<IOutputPortNotFound, AddVehicleOutputPort>();
            services.AddScoped<IOutputPortNotFound, ListAvailableVehiclesOutputPort>();
            services.AddScoped<IOutputPortNotFound, RentVehicleOutputPort>();
            services.AddScoped<IOutputPortNotFound, ReturnVehicleOutputPort>();
            services.AddScoped<IOutputPortNotFound, ListActiveRentalsOutputPort>();
            return services;
        }
    }
}
