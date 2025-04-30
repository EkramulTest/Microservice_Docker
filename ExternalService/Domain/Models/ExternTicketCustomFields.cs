namespace ExternalService.Domain.Models
{
    public class ExternTicketCustomFields
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public int ExternalTicketConfigId { get; set; }
        public string CustomFieldId { get; set; }
        public bool IsActive { get; set; }
    }
}
