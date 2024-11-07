using AWEPP.Modelo;
using AWEPP.Model;
using AWEPP.Models;
namespace AWEPP.Services
{
    public interface IAuditService
    {
        Task LogEventAsync(AuditLog log);
    }
}
