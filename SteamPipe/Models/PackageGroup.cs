using SteamPipe.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamPipe
{
    [JsonConverter(typeof(PackageGroupJsonConverter))]
    public class PackageGroup
    {
        internal PackageGroup()
        {
        }

        [JsonConstructor]
        public PackageGroup(string description, string isRecurringSubscription, string name, string savetext, string selectionText, int displayType, IReadOnlyList<Sub> subs, string title) =>
            (Description, IsRecurringSubscription, Name, SaveText, SelectionText, DisplayType, Subs, Title) = (description, isRecurringSubscription, name, savetext, selectionText, displayType, subs, title);

        [JsonPropertyName("description")]
        public virtual string Description { get; internal set; }

        [JsonPropertyName("is_recurring_subscription")]
        public virtual string IsRecurringSubscription { get; internal set; }

        [JsonPropertyName("name")]
        public virtual string Name { get; internal set; }

        [JsonPropertyName("save_text")]
        public virtual string SaveText { get; internal set; }

        [JsonPropertyName("selection_text")]
        public virtual string SelectionText { get; internal set; }

        [JsonPropertyName("display_type")]
        public virtual int DisplayType { get; internal set; }

        [JsonPropertyName("subs")]
        public virtual IReadOnlyList<Sub> Subs { get; internal set; }

        [JsonPropertyName("title")]
        public virtual string Title { get; internal set; }
    }
}