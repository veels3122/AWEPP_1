namespace AWEPP.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public string RecordId { get; set; }
        public string Changes { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(-5);
    }
}
