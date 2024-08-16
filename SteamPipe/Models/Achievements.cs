using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamPipe
{
    public class Achievements
    {
        [JsonConstructor]
        public Achievements(int total, IReadOnlyList<Highlighted> highlighted) =>
            (Total, Highlighted) = (total, highlighted);

        /// <summary>
        /// Rotating selection of achivements shown on the store page
        /// </summary>
        [JsonPropertyName("highlighted")]
        public virtual IReadOnlyList<Highlighted> Highlighted { get; }

        /// <summary>
        /// Total achivements for the app
        /// </summary>
        [JsonPropertyName("total")]
        public virtual int Total { get; }
    }
}