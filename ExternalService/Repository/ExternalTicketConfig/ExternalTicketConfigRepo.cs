using ExternalService.Domain.Data;
using ExternalService.Domain.ViewModel;
using ExternalService.Repository.ExternalTicketConfigRepo;
using Microsoft.EntityFrameworkCore;

namespace ExternalService.Repository.ExternalTicketConfig
{
    public class ExternalTicketConfigRepo : IExternalTicketConfigRepo
    {
        private readonly ILogger<IExternalTicketConfigRepo> _logger;
        private readonly ExternalServiceDBContext _repositoryContext;

        public ExternalTicketConfigRepo(ILogger<IExternalTicketConfigRepo> logger, ExternalServiceDBContext repositoryContext)
        {
            this._logger = logger;
            this._repositoryContext = repositoryContext;
        }

        public async Task<ExternalTicketConfigVM> GetExternalTicketingCredentialsAsync(ExternalTicketConfigVM config)
        {
            try
            {
                var credentialResponse = await (
                    from a in _repositoryContext.ExternalTicketConfigg
                    join b in _repositoryContext.ExternTicketCustomFieldss
                        .Where(x => x.IsActive)
                        on a.Id equals b.ExternalTicketConfigId into abGroup
                    from b in abGroup.DefaultIfEmpty()
                    where a.IsActive == true && a.CompanyId == config.CId && a.ProjectId == config.PId
                    && a.MasterTicketingToolId == config.Credentials.MasterTicketingToolId
                    select new ExternalTicketConfigVM
                    {
                        Id = a.Id,
                        CId = a.CompanyId,
                        PId = a.ProjectId,
                        Credentials = new ExternalTicketConfigResponseVM
                        {
                            BaseUrl = a.BaseUrl,
                            UserEmail = a.UserEmail,
                            ApiToken = a.ApiToken,
                            ProjectKey = a.ProjectKey,
                            CustomFieldId = b != null ? b.CustomFieldId : null,
                            MasterTicketingToolId = a.MasterTicketingToolId
                        }
                    }).FirstOrDefaultAsync().ConfigureAwait(false);

                if (credentialResponse != null && credentialResponse.Id > 0)
                {
                    return credentialResponse;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has occured in ExternalTicketConfigRepo - GetExternalTicketingCredentials");
            }
            return null;
        }
    }
}
