namespace LaLigaInfraestructure.Redis
{
    public interface IRedisService
    {
        Task SaveInRedis<T>(string key, T value);

        Task<T?> GetFromRedis<T>(string key);
    }
}
