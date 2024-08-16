using System.Text.Json.Serialization;

namespace SteamPipe
{
    /// <summary>
    /// <para>A package is a collection of one or more applications and depots
    /// that can be sold via Steam or can be granted to users based on the activation
    /// of a Steam key. This can be thought of as an SKU or a license.</para>
    /// <para>After a user purchases or activates a package, the contents of that
    /// package dictate which applications or depot contents the user has permission
    /// to download and launch.</para>
    /// <para>Part of <see cref="PackageGroup"/></para>
    /// </summary>
    /// <remarks><seealso href="https://partner.steamgames.com/doc/store/application/packages"/></remarks>
    public class Sub
    {
        [JsonConstructor]
        public Sub(int packageId, string canGetFreeLicense, bool isFreeLicense, string optionDescription, string optionText, int percentSavings, string percentSavingsText, int priceInCentsWithDiscount) =>
            (PackageId, CanGetFreeLicense, IsFreeLicense, OptionDescription, OptionText, PercentSavings, PercentSavingsText, PriceInCentsWithDiscount) = (packageId, canGetFreeLicense, isFreeLicense, optionDescription, optionText, percentSavings, percentSavingsText, priceInCentsWithDiscount);

        [JsonPropertyName("packageid")]
        public virtual int PackageId { get; }

        [JsonPropertyName("can_get_free_license")]
        public virtual string CanGetFreeLicense { get; }

        [JsonPropertyName("is_free_license")]
        public virtual bool IsFreeLicense { get; }

        [JsonPropertyName("option_description")]
        public virtual string OptionDescription { get; }

        [JsonPropertyName("option_text")]
        public virtual string OptionText { get; }

        [JsonPropertyName("percent_savings")]
        public virtual int PercentSavings { get; }

        [JsonPropertyName("percent_savings_text")]
        public virtual string PercentSavingsText { get; }

        [JsonPropertyName("price_in_cents_with_discount")]
        public virtual int PriceInCentsWithDiscount { get; }
    }
}