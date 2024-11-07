using System.Threading.Tasks;
using AWEPP.Models;
using AWEPP.Context;
using AWEPP.Services;

public class AuditService :IAuditService
{
    private readonly Aweppcontext _context;

    public AuditService(Aweppcontext context)
    {
        _context = context;
    }

    public async Task LogEventAsync(AuditLog auditLog)
    {
       

        _context.AuditLogs.Add(auditLog);
        await _context.SaveChangesAsync();
    }

    
}
