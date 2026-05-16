using Portfolio.Application.Common.Interfaces;
using Portfolio.Infrastructure.Data;

namespace Portfolio.Infrastructure.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly PortfolioDbContext _db;

        public HealthCheckService(PortfolioDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CanConnectToDatabaseAsync()
        {
            return await _db.Database.CanConnectAsync();
        }
    }
}
