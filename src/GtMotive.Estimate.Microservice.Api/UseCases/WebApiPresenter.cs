using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public sealed class WebApiPresenter : IWebApiPresenter, IOutputPortStandard<IUseCaseOutput>, IOutputPortNotFound
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(IUseCaseOutput response)
        {
            ActionResult = new OkObjectResult(response);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(new { message });
        }
    }
}
