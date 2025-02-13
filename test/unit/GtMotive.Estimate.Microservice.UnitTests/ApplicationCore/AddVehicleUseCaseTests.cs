using System;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.AddVehicleUseCase;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    /// <summary>
    /// Test class for the AddVehicleUseCase.
    /// </summary>
    public class AddVehicleUseCaseTests
    {
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        private readonly Mock<IOutputPortStandard<AddVehicleUseCaseOutput>> _mockOutputPortStandard;
        private readonly Mock<IOutputPortNotFound> _mockOutputPortNotFound;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AddVehicleUseCase _addVehicleUseCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddVehicleUseCaseTests"/> class.
        /// Initializes the test class, setting up mocks and the AddVehicleUseCase instance.
        /// </summary>
        public AddVehicleUseCaseTests()
        {
            _mockVehicleRepository = new Mock<IVehicleRepository>();
            _mockOutputPortStandard = new Mock<IOutputPortStandard<AddVehicleUseCaseOutput>>();
            _mockOutputPortNotFound = new Mock<IOutputPortNotFound>();
            _mockMapper = new Mock<IMapper>();

            _addVehicleUseCase = new AddVehicleUseCase(
                _mockVehicleRepository.Object,
                _mockOutputPortStandard.Object,
                _mockOutputPortNotFound.Object,
                _mockMapper.Object);
        }

        /// <summary>
        /// Tests the Execute method to ensure the repository and output port are called when the vehicle is valid.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task ExecuteShouldCallRepositoryAndOutputPortWhenVehicleIsValid()
        {
            var input = new AddVehicleUseCaseInput
            {
                Brand = "Peugeot",
                Model = "308",
                ManufacturingDate = 2020,
                LicensePlate = "5070CTX"
            };

            var vehicle = new Vehicle
            {
                Brand = input.Brand,
                Model = input.Model,
                YearOfManufacture = input.ManufacturingDate,
                LicensePlate = input.LicensePlate
            };

            var output = new AddVehicleUseCaseOutput
            {
                VehicleId = string.Empty,
                Message = string.Empty
            };

            _mockMapper.Setup(m => m.Map<Vehicle>(It.IsAny<AddVehicleUseCaseInput>())).Returns(vehicle);
            _mockMapper.Setup(m => m.Map<AddVehicleUseCaseOutput>(It.IsAny<Vehicle>())).Returns(output);
            _mockVehicleRepository.Setup(r => r.AddAsync(It.IsAny<Vehicle>())).Returns(Task.CompletedTask);

            await _addVehicleUseCase.Execute(input);

            _mockVehicleRepository.Verify(r => r.AddAsync(It.IsAny<Vehicle>()), Times.Once);
            _mockOutputPortStandard.Verify(op => op.StandardHandle(It.IsAny<AddVehicleUseCaseOutput>()), Times.Once);
            _mockOutputPortNotFound.Verify(op => op.NotFoundHandle(It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// Tests the Execute method to ensure NotFoundHandle is called when the vehicle is invalid.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task ExecuteShouldCallNotFoundHandleWhenVehicleIsInvalid()
        {
            var input = new AddVehicleUseCaseInput
            {
                Brand = "Peugeot",
                Model = "308",
                ManufacturingDate = 2015,
                LicensePlate = "5070CTX"
            };

            var vehicle = new Vehicle
            {
                Brand = input.Brand,
                Model = input.Model,
                YearOfManufacture = input.ManufacturingDate,
                LicensePlate = input.LicensePlate
            };

            _mockMapper.Setup(m => m.Map<Vehicle>(It.IsAny<AddVehicleUseCaseInput>())).Returns(vehicle);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _addVehicleUseCase.Execute(input));

            _mockOutputPortNotFound.Verify(op => op.NotFoundHandle(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        /// Tests the Execute method to ensure unexpected errors are handled correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task ExecuteShouldHandleUnexpectedErrors()
        {
            var input = new AddVehicleUseCaseInput
            {
                Brand = "Peugeot",
                Model = "308",
                ManufacturingDate = 2024,
                LicensePlate = "5070CTX"
            };

            var vehicle = new Vehicle
            {
                Brand = input.Brand,
                Model = input.Model,
                YearOfManufacture = input.ManufacturingDate,
                LicensePlate = input.LicensePlate
            };

            _mockMapper.Setup(m => m.Map<Vehicle>(It.IsAny<AddVehicleUseCaseInput>())).Returns(vehicle);
            _mockVehicleRepository.Setup(r => r.AddAsync(It.IsAny<Vehicle>())).Throws(new InvalidOperationException("An unexpected error occurred"));

            await Assert.ThrowsAsync<InvalidOperationException>(() => _addVehicleUseCase.Execute(input));

            _mockOutputPortNotFound.Verify(op => op.NotFoundHandle(It.Is<string>(msg => msg.Contains("An unexpected error occurred"))), Times.Once);
        }
    }
}
