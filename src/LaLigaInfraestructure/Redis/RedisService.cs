using Newtonsoft.Json;
using StackExchange.Redis;

namespace LaLigaInfraestructure.Redis
{
    public class RedisService(IConnectionMultiplexer redis) : IRedisService
    {
        private readonly IDatabase _redisDatabase = redis.GetDatabase();

        public async Task SaveInRedis<T>(string key, T value)
        {
            var serializedValue = JsonConvert.SerializeObject(value);z
            await _redisDatabase.StringSetAsync(key, serializedValue);
        }

        public async Task<T?> GetFromRedis<T>(string key)
        {
            var serializedValue = await _redisDatabase.StringGetAsync(key);
            if (serializedValue.IsNullOrEmpty)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(serializedValue);
        }
    }
}
