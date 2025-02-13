using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Entities;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicleUseCase;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicleUseCase;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.Mapping
{
    /// <summary>
    /// Profile for mapping.
    /// </summary>
    public class MapProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapProfile"/> class.
        /// </summary>
        public MapProfile()
        {
            CreateMap<AddVehicleUseCaseInput, Vehicle>()
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.LicensePlate))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => true));

            CreateMap<Vehicle, AddVehicleUseCaseOutput>()
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => $"Vehicle {src.Brand} {src.Model} added successfully."));

            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.LicensePlate))
                .ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => src.YearOfManufacture));

            CreateMap<RentVehicleUseCaseInput, Rental>()
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName));

            CreateMap<Rental, RentVehicleUseCaseOutput>()
                .ForMember(dest => dest.RentalId, opt => opt.MapFrom(src => src.RentalId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => $"Vehicle {src.VehicleId} rent successfully."));

            CreateMap<Rental, ReturnVehicleUseCaseOutput>()
                .ForMember(dest => dest.RentalId, opt => opt.MapFrom(src => src.RentalId))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => $"Vehicle {src.VehicleId} returned successfully."));

            CreateMap<Rental, RentalDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RentalId))
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.RentalDate, opt => opt.MapFrom(src => src.StartDate));
        }
    }
}
