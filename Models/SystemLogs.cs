using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("SystemLogs")]
public class SystemLogs
{
    public int Id { get; set; }
    public string Message { get; set; } = null!;
    public string? StackTrace { get; set; }
    public string? Source { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? UserName { get; set; }
}