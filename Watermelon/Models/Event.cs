namespace Watermelon.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// An activity.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Gets or sets the description of the queried activity.
        /// </summary>
        [JsonProperty("activity", NullValueHandling = NullValueHandling.Ignore)]
        public string Activity { get; set; }

        /// <summary>
        /// Gets or sets the type of the activity.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the number of people that this activity could involve.
        /// </summary>
        [JsonProperty("participants", NullValueHandling = NullValueHandling.Ignore)]
        public long? Participants { get; set; }

        /// <summary>
        /// Gets or sets a factor describing the cost of the event with zero being free.
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        /// <summary>
        /// Gets or sets the link of the activity.
        /// </summary>
        [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets a unique numeric id.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Key { get; set; }

        /// <summary>
        /// Gets or sets a factor describing how possible an event is to do with zero being the most accessible.
        /// </summary>
        [JsonProperty("accessibility", NullValueHandling = NullValueHandling.Ignore)]
        public double? Accessibility { get; set; }
    }

    /// <summary>
    /// An activity.
    /// </summary>
    public partial class Event
    {
        /// <summary>
        /// Converts JSON to <see cref="Event"/>.
        /// </summary>
        /// <param name="json">The JSON to be converted.</param>
        /// <returns>A converted <see cref="Event"/> object.</returns>
        public static Event FromJson(string json) => JsonConvert.DeserializeObject<Event>(json, Converter.Settings);
    }
}
