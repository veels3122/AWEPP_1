using System.IO;
using System.Threading.Tasks;
using AWEPP.Context;
using AWEPP.Models;
using AWEPP.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class AuditService : IAuditService
{
    private readonly ILogger<AuditService> _logger;
    private readonly Aweppcontext _context;
    private const string AuditLogFilePath = "AuditLog.txt"; // Define el nombre del archivo de log de auditoría.

    public AuditService(ILogger<AuditService> logger, Aweppcontext context)
    {
        _logger = logger;
        _context = context;
    }
  


    public async Task LogEventAsync(AuditLog auditLog)
    {
        // Guardar en la base de datos (si ya tienes esa implementación)
         await _context.AuditLogs.AddAsync(auditLog);
         await _context.SaveChangesAsync();

        // Guardar en archivo de texto
        var logMessage = $"Fecha: {auditLog.Date}, Acción: {auditLog.Action}, " +
                         $"Tabla: {auditLog.TableName}, ID Registro: {auditLog.RecordId}, " +
                         $"Cambios: {auditLog.Changes}, Usuario: {auditLog.UserName}\n";

        await File.AppendAllTextAsync(AuditLogFilePath, logMessage);
        _logger.LogInformation(logMessage); // Esto también registra en el sistema de logging general
    }
}
