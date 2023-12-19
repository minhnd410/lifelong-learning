using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Herond.Benchmarks.Models;

public class MetricLogRequest
{
    [JsonPropertyName("cadence")]
    public string Cadence { get; set; }

    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    [JsonPropertyName("metric_name")]
    public string MetricName { get; set; }

    [JsonPropertyName("metric_value")]
    public int MetricValue { get; set; }

    [JsonPropertyName("platform")]
    public string Platform { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    /// <summary>
    /// Day of survey
    /// </summary>
    [JsonPropertyName("dos")]
    [BsonIgnoreIfNull]
    public int? Dos { get; set; }

    /// <summary>
    /// Week of installation
    /// </summary>
    [JsonPropertyName("woi")]
    public int Woi { get; set; }

    /// <summary>
    /// Week of survey
    /// </summary>
    [JsonPropertyName("wos")]
    [BsonIgnoreIfNull]
    public int? Wos { get; set; }

    /// <summary>
    /// Month of survey
    /// </summary>
    [JsonPropertyName("mos")]
    [BsonIgnoreIfNull]
    public int? Mos { get; set; }

    /// <summary>
    /// Year of installation
    /// </summary>
    [JsonPropertyName("yoi")]
    public int Yoi { get; set; }

    /// <summary>
    /// Year of survey
    /// </summary>
    [JsonPropertyName("yos")]
    [BsonIgnoreIfNull]
    public int? Yos { get; set; }
}