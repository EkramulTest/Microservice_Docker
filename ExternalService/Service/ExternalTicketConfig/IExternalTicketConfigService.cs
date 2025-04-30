using ExternalService.Domain.ViewModel;

namespace ExternalService.Service.ExternalTicketConfig
{
    public interface IExternalTicketConfigService
    {
        Task<ExternalTicketConfigVM> GetExternalTicketingCredentialsAsync(int? CompanyId, int? ProjectId, int? MasterTicketingToolId);
    }
}
