using ExternalService.Domain.ViewModel;

namespace ExternalService.Repository.ExternalTicketConfigRepo
{
    public interface IExternalTicketConfigRepo
    {
        Task<ExternalTicketConfigVM> GetExternalTicketingCredentialsAsync(ExternalTicketConfigVM config);
    }
}
