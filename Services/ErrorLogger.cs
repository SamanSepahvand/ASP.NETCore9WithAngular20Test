using CoreAngular1.Data;

namespace CoreAngular1.Services
{
    public class ErrorLogger
    {
        private readonly AppDbContext _context;

        public ErrorLogger(AppDbContext context)
        {
            _context = context;
        }

        public void Log(Exception ex, string? userName = null)
        {
            var log = new SystemLogs
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source,
                UserName = userName
            };

            _context.SystemLogs.Add(log);
            _context.SaveChanges();
        }
    }

}
