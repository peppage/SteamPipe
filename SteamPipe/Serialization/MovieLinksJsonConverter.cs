using SteamPipe.Internal;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamPipe.Serialization
{
    internal class MovieLinksJsonConverter : JsonConverter<MovieLinks>
    {
        public override MovieLinks? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var data = new MovieLinks();

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
                    case "480":
                        data.Resolution480 = reader.GetString();
                        break;

                    case "max":
                        data.ResolutionMax = reader.GetString();
                        break;
                }
            }

            return data;
        }

        public override void Write(Utf8JsonWriter writer, MovieLinks value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}