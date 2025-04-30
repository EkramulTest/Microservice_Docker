using ExternalService.Domain.ViewModel;
using ExternalService.Repository.ExternalTicketConfigRepo;
using System.ComponentModel.Design;

namespace ExternalService.Service.ExternalTicketConfig
{
    public class ExternalTicketConfigService : IExternalTicketConfigService
    {
        private readonly ILogger<IExternalTicketConfigService> _logger;
        private readonly IExternalTicketConfigRepo _iExternalTicketConfigRepo;
        public ExternalTicketConfigService(ILogger<IExternalTicketConfigService> logger, IExternalTicketConfigRepo iExternalTicketConfigRepo)
        {
            this._logger = logger;
            this._iExternalTicketConfigRepo = iExternalTicketConfigRepo;
        }

        public async Task<ExternalTicketConfigVM> GetExternalTicketingCredentialsAsync(int? CompanyId, int? ProjectId, int? MasterTicketingToolId)
        {
            try
            {
                var cred = new ExternalTicketConfigVM
                {
                    CId = CompanyId,
                    PId = ProjectId,
                    Credentials = new ExternalTicketConfigResponseVM
                    {
                        MasterTicketingToolId = MasterTicketingToolId
                    }
                };
                return await _iExternalTicketConfigRepo.GetExternalTicketingCredentialsAsync(cred);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured in ExternalTicketConfigService - GetExternalTicketingCredentials");
            }
            return null;
        }
    }
}
