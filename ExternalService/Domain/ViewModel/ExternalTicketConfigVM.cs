namespace ExternalService.Domain.ViewModel
{
    public class ExternalTicketConfigVM
    {
        public int? Id { get; set; }
        public int? CId { get; set; }
        public int? PId { get; set; }
        public string? CompanyId { get; set; }
        public string? ProjectId { get; set; }
        public ExternalTicketConfigResponseVM? Credentials { get; set; }
    }

    public class ExternalTicketConfigResponseVM
    {
        public string? BaseUrl { get; set; }
        public string? UserEmail { get; set; }
        public string? ApiToken { get; set; }
        public string? ProjectKey { get; set; }
        public string? CustomFieldId { get; set; }
        public int? MasterTicketingToolId { get; set; }
    }

    public class ExternalTicketCredentialsVM
    {
        public int? Id { get; set; }
        public int? CId { get; set; }
        public int? PId { get; set; }
        public string? CompanyId { get; set; }
        public string? ProjectId { get; set; }
        public string? BaseUrl { get; set; }
        public string? UserEmail { get; set; }
        public string? ApiToken { get; set; }
        public string? ProjectKey { get; set; }
        public string? CustomFieldId { get; set; }
        public int? MasterTicketingToolId { get; set; }
    }

    public class ExternalTicketRequestVM
    {
        public string? CompanyId { get; set; }
        public string? ProjectId { get; set; }
        public int? CId { get; set; }
        public int? PId { get; set; }
        public int? MasterTicketingToolId { get; set; }
    }
}
