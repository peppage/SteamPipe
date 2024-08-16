using SteamPipe.Internal;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamPipe.Serialization
{
    internal class AppDetailsContainerJsonConverter : JsonConverter<AppDetails>
    {
        public override AppDetails? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var data = new AppData();
            var success = false;

            // Read past the start token and initial property with app id. Can't
            // Skip() because it skips children.
            reader.Read();
            reader.Read();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    // Must continue reading until it fails because
                    // there are multiple objects.
                    if (reader.Read())
                    {
                        continue;
                    }
                    else
                    {
                        return new AppDetails(data, success);
                    }
                }
                else if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                var propertyName = reader.GetString();
                reader.Read(); // Advance the reader to the property value.
                switch (propertyName)
                {
                    case "success":
                        success = reader.GetBoolean();
                        break;

                    case "data":
                        // Read into data which is another object
                        break;

                    case "name":
                        data.Name = reader.GetString() ?? "";
                        break;

                    case "type":
                        data.Type = reader.GetString() ?? "";
                        break;

                    case "steam_appid":
                        data.AppId = reader.GetUInt32();
                        break;

                    case "required_age":
                        try
                        {
                            data.RequiredAge = reader.GetString() ?? "";
                        }
                        catch
                        {
                            // For some apps the value is an int, we can ignore it then.
                        }
                        break;

                    case "controller_support":
                        data.ControllerSupport = reader.GetString() ?? "";
                        break;

                    case "is_free":
                        data.IsFree = reader.GetBoolean();
                        break;

                    case "dlc":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Dlc = doc.Deserialize<IReadOnlyList<uint>>();
                        }
                        break;

                    case "detailed_description":
                        data.DetailedDescription = reader.GetString() ?? "";
                        break;

                    case "about_the_game":
                        data.AboutTheGame = reader.GetString() ?? "";
                        break;

                    case "short_description":
                        data.ShortDescription = reader.GetString() ?? "";
                        break;

                    case "supported_languages":
                        data.SupportedLanguages = reader.GetString() ?? "";
                        break;

                    case "reviews":
                        data.Reviews = reader.GetString() ?? "";
                        break;

                    case "header_image":
                        data.HeaderImage = reader.GetString() ?? "";
                        break;

                    case "website":
                        data.Website = reader.GetString() ?? "";
                        break;

                    case "pc_requirements":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            try
                            {
                                data.PCRequirements = doc.Deserialize<Requirements>();
                            }
                            catch
                            {
                                // If not avail the API returns [].
                            }
                        }
                        break;

                    case "mac_requirements":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            try
                            {
                                data.MacRequirements = doc.Deserialize<Requirements>();
                            }
                            catch
                            {
                                // If not avail the API returns [].
                            }
                        }

                        break;

                    case "linux_requirements":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            try
                            {
                                data.LinuxRequirements = doc.Deserialize<Requirements>();
                            }
                            catch
                            {
                                // If not avail the API returns [].
                            }
                        }
                        break;

                    case "legal_notice":
                        data.LegalNotice = reader.GetString() ?? "";
                        break;

                    case "developers":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Developers = doc.Deserialize<IReadOnlyList<string>>();
                        }
                        break;

                    case "publishers":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Publishers = doc.Deserialize<IReadOnlyList<string>>();
                        }
                        break;

                    case "price_overview":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.PriceOverview = doc.Deserialize<Price>();
                        }
                        break;

                    case "packages":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Packages = doc.Deserialize<IReadOnlyList<uint>>();
                        }
                        break;

                    case "package_groups":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.PackageGroups = doc.Deserialize<IReadOnlyList<PackageGroup>>();
                        }
                        break;

                    case "platforms":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Platforms = doc.Deserialize<Platforms>();
                        }
                        break;

                    case "metacritic":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Metacritic = doc.Deserialize<Metacritic>();
                        }
                        break;

                    case "categories":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Categories = doc.Deserialize<IReadOnlyList<Category>>();
                        }
                        break;

                    case "genres":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Genres = doc.Deserialize<IReadOnlyList<Genre>>();
                        }
                        break;

                    case "movies":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Movies = doc.Deserialize<IReadOnlyList<Movie>>();
                        }
                        break;

                    case "screenshots":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Screenshots = doc.Deserialize<IReadOnlyList<Screenshot>>();
                        }
                        break;

                    case "recommendations":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Recommendations = doc.Deserialize<Recommendations>();
                        }
                        break;

                    case "achievements":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.Achievements = doc.Deserialize<Achievements>();
                        }
                        break;

                    case "release_date":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.ReleaseDate = doc.Deserialize<ReleaseDate>();
                        }
                        break;

                    case "support_info":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.SupportInfo = doc.Deserialize<SupportInfo>();
                        }
                        break;

                    case "background":
                        data.Background = reader.GetString();
                        break;

                    case "background_raw":
                        data.BackgroundRaw = reader.GetString();
                        break;

                    case "content_descriptors":
                        using (var doc = JsonDocument.ParseValue(ref reader))
                        {
                            data.ContentDescriptors = doc.Deserialize<ContentDescriptors>();
                        }
                        break;

                    default:
                        reader.Skip(); break;
                }
            }

            if (success)
            {
                throw new JsonException();
            }

            return new AppDetails(data, success);
        }

        public override void Write(Utf8JsonWriter writer, AppDetails value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}