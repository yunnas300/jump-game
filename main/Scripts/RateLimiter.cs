using System.Collections.Concurrent;

public class RateLimiter
{
    private static readonly ConcurrentDictionary<string, DateTime> RequestLog = new();
    private static readonly TimeSpan LimitInterval = TimeSpan.FromSeconds(10);

    public static bool IsRequestAllowed(string ipAddress)
    {
        if (RequestLog.TryGetValue(ipAddress, out var lastRequestTime))
        {
            if (DateTime.UtcNow - lastRequestTime < LimitInterval)
            {
                return false;
            }
        }
        RequestLog[ipAddress] = DateTime.UtcNow;
        return true;
    }
}

public IActionResult GameRequest(string ipAddress)
{
    if (!RateLimiter.IsRequestAllowed(ipAddress))
    {
        return StatusCode(429, "Too many requests. Please wait.");
    }

    return Ok();
}
