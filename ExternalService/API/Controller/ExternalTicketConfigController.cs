using ExternalService.Domain.ViewModel;
using ExternalService.Service.ExternalTicketConfig;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExternalService.API.Controller
{
    [Route("externalServiceApi/[controller]")]
    [ApiController]
    public class ExternalTicketConfigController : ControllerBase
    {
        private readonly IExternalTicketConfigService _iExternalTicketConfigService;
        private readonly ILogger<ExternalTicketConfigController> _logger;

        public ExternalTicketConfigController(IExternalTicketConfigService iExternalTicketConfigService, ILogger<ExternalTicketConfigController> logger)
        {
            this._iExternalTicketConfigService = iExternalTicketConfigService;
            this._logger = logger;
        }

        [HttpPost("GetExternalTicketingUserCredentials")]
        public async Task<IActionResult> GetExternalTicketingUserCredentials(ExternalTicketRequestVM model)
        {
            if(model.CId > 0 && model.PId > 0 && model.MasterTicketingToolId > 0)
            {
                var result = await _iExternalTicketConfigService.GetExternalTicketingCredentialsAsync(model.CId, model.PId, model.MasterTicketingToolId);
                if(result != null)
                {
                    return Ok(result);
                }
            }
            return StatusCode(500, "No data found");
        }
    }
}
