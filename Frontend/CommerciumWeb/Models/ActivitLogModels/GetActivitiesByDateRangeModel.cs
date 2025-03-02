using System;
using System.Text.Json.Serialization;

public class GetActivitiesByDateRangeModel
{
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }
}
