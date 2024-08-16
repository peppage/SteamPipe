using SteamPipe.Internal;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamPipe.Serialization
{
    internal class PackageGroupJsonConverter : JsonConverter<PackageGroup>
    {
        public override PackageGroup? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var data = new PackageGroup();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return data;
                }
                else if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                var propertyName = reader.GetString();
                reader.Read(); // Advance the reader to the property value.

                switch (propertyName)
                {
                    case "name":
                        data.Name = reader.GetString();
                        break;

                    case "title":
                        data.Title = reader.GetString();
                        break;

                    case "description":
                        data.Description = reader.GetString();
                        break;

                    case "selection_text":
                        data.SelectionText = reader.GetString();
                        break;

                    case "save_text":
                        data.SaveText = reader.GetString();
                        break;

                    case "display_type":
                        var cachedDisplayType = JsonDocument.ParseValue(ref reader);
                        try
                        {
                            data.DisplayType = JsonSerializer.Deserialize<int>(cachedDisplayType.RootElement.GetRawText());
                            break;
                        }
                        catch { }
                        try
                        {
                            var val = JsonSerializer.Deserialize<string>(cachedDisplayType.RootElement.GetRawText());
                            data.DisplayType = int.Parse(val);
                            break;
                        }
                        catch { }
                        break;

                    case "is_recurring_subscription":
                        data.IsRecurringSubscription = reader.GetString();
                        break;

                    case "subs":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Subs = doc.Deserialize<IReadOnlyList<Sub>>();
                        }
                        break;
                }
            }

            return data;
        }

        public override void Write(Utf8JsonWriter writer, PackageGroup value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}