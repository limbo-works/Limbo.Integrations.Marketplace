using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Limbo.Integrations.Marketplace.Models.Authors;

public class MarketplaceAuthorDetails : MarketplaceObject {

    public string? Description { get; }

    [MemberNotNullWhen(true, "Description")]
    public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

    public string? Url { get; }

    [MemberNotNullWhen(true, "Url")]
    public bool HasUrl => !string.IsNullOrWhiteSpace(Url);

    public string? ImageUrl { get; }

    [MemberNotNullWhen(true, "ImageUrl")]
    public bool HasImageUrl => !string.IsNullOrWhiteSpace(ImageUrl);

    private MarketplaceAuthorDetails(JObject json) : base(json) {
        Description = json.GetString("description");
        Url = json.GetString("url");
        ImageUrl = json.GetString("imageUrl");
    }

    public static MarketplaceAuthorDetails Parse(JObject parse) {
        return new MarketplaceAuthorDetails(parse);
    }

}