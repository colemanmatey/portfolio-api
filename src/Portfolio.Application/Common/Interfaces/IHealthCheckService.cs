namespace Portfolio.Application.Common.Interfaces
{
    public interface IHealthCheckService
    {
        Task<bool> CanConnectToDatabaseAsync();
    }
}
