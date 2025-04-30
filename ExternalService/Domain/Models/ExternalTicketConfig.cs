namespace ExternalService.Domain.Models
{
    public class ExternalTicketConfig
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string BaseUrl { get; set; }
        public string UserEmail { get; set; }
        public string? ApiToken { get; set; }
        public string? ProjectKey { get; set; }
        public int? MasterTicketingToolId { get; set; }
        public bool? IsActive { get; set; }
    }
}