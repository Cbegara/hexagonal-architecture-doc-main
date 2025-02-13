namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehiclesUseCase
{
    /// <summary>
    /// Represents the input for the ListAvailableVehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets a default instance of the input.
        /// </summary>
        public static ListAvailableVehiclesUseCaseInput Default => new();
    }
}
