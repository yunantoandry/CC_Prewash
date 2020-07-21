using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Common.Services.Scheduling.DTO
{
    /// <summary>
    /// Represents when a BackgroundProcess should run next, if it exists.
    /// </summary>
    public class WhenToRunNextDto
    {
        public DateTime? DateTime { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WhenToRunNextResultType ResultType { get; set; }
    }
}
