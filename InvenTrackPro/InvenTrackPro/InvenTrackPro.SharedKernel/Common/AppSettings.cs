namespace InvenTrackPro.SharedKernel.Common;
public class AppSettings
{
    public Domain Domain { get; set; }
    public JwtConfig JwtConfig { get; set; }
    public CacheConfig CacheConfig { get; set; }
    public Cms Cms { get; set; }
    public RabbitMqConnection RabbitMq { get; set; }
    public EmailSetting EmailSetting { get; set; }
    public SmsSetting SmsSetting { get; set; }
    public ClientApp ClientApp { get; set; }
}

public class Domain
{
    public List<string> ClientOne { get; set; }
    public List<string> ClientTwo { get; set; }
    public List<string> All { get; set; }
    public string DomainName { get; set; }
}

public class RabbitMqConnection
{
    public string Host { get; set; }
    public string VirtualHost { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string QName { get; set; }
    public int PrefetchCount { get; set; }
}

public class JwtConfig
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecretKey { get; set; }
    public string Alg { get; set; }
    public uint ValidForInMinutes { get; set; }
    public uint RefreshTokenValidForInDays { get; set; }
    public uint LockUserJwtInMinutes { get; set; }
    public bool IsValidateIssuer { get; set; }
    public bool IsValidateAudience { get; set; }
    public bool IsValidateIssuerSigningKey { get; set; }
    public bool IsRequireExpirationTime { get; set; }
    public bool IsValidateLifetime { get; set; }
    public string AuthenticationScheme { get; set; }
    public string TokenType { get; set; }
}

public class CacheConfig
{
    public uint BaseControllerCacheDuration { get; set; }
    public CacheKeyDuration HoldingQueuePaged { get; set; }
    public uint LifeLineSyncDurationInMinute { get; set; }
}

public class Cms
{
    public string Api { get; set; }
}

public class CacheKeyDuration
{
    public string CacheKey { get; set; }
    public uint Duration { get; set; }
}

public class EmailSetting
{
    public string SenderEmail { get; set; }
    public string HostServer { get; set; }
    public int SmtpPort { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsSSL { get; set; }
    public bool IsAsync { get; set; }
    public int TryLimit { get; set; }
}

public class SmsSetting
{
    public string Url { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int TryLimit { get; set; }
}

public class ClientApp
{
    public string BaseUrl { get; set; }
}
