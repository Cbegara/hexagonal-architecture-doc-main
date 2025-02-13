using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GtMotive.Estimate.Microservice.ApplicationCore.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListActiveRentalsUseCase
{
    /// <summary>
    /// Use case for listing active rentals.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListActiveRentalsUseCase"/> class.
    /// </remarks>
    /// <param name="rentalRepository">The rental repository.</param>
    /// <param name="outputPortStandard">The standard output port.</param>
    /// <param name="outputPortNotFound">The not found output port.</param>
    /// <param name="mapper">The mapper.</param>
    /// <exception cref="ArgumentNullException">Thrown when any of the parameters are null.</exception>
    public sealed class ListActiveRentalsUseCase(
        IRentalRepository rentalRepository,
        IOutputPortStandard<ListActiveRentalsUseCaseOutput> outputPortStandard,
        IOutputPortNotFound outputPortNotFound,
        IMapper mapper) : IUseCase<ListActiveRentalsUseCaseInput>
    {
        private readonly IRentalRepository _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
        private readonly IOutputPortStandard<ListActiveRentalsUseCaseOutput> _outputPortStandard = outputPortStandard ?? throw new ArgumentNullException(nameof(outputPortStandard));
        private readonly IOutputPortNotFound _outputPortNotFound = outputPortNotFound ?? throw new ArgumentNullException(nameof(outputPortNotFound));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        /// <summary>
        /// Executes the use case.
        /// </summary>
        /// <param name="input">The input for the use case.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task Execute(ListActiveRentalsUseCaseInput input)
        {
            try
            {
                var activeRentals = await _rentalRepository.GetActiveRentalsAsync();
                var activeRentalsDto = _mapper.Map<IEnumerable<RentalDto>>(activeRentals);

                var output = new ListActiveRentalsUseCaseOutput(activeRentalsDto);

                if (output.ActiveRentals.Count == 0)
                {
                    _outputPortNotFound.NotFoundHandle("There aren´t active rentals at this moment.");
                }
                else
                {
                    _outputPortStandard.StandardHandle(output);
                }
            }
            catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
            {
                _outputPortNotFound.NotFoundHandle(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _outputPortNotFound.NotFoundHandle("An unexpected error occurred: " + ex.Message);
                throw;
            }
        }
    }
}
