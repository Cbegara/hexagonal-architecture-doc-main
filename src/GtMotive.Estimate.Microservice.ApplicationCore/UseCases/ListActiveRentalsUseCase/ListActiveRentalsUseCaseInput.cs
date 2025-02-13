namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListActiveRentalsUseCase
{
    /// <summary>
    /// Represents the input for the ListActiveRentals use case.
    /// </summary>
    public sealed class ListActiveRentalsUseCaseInput : IUseCaseInput
    {
        /// <summary>
        /// Gets a default instance of the input.
        /// </summary>
        public static ListActiveRentalsUseCaseInput Default => new();
    }
}
