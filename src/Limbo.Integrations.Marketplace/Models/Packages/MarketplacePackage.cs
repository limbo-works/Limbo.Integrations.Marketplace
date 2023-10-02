using System.Diagnostics.CodeAnalysis;
using Limbo.Integrations.Marketplace.Models.Authors;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.Marketplace.Models.Packages;

public class MarketplacePackage : MarketplaceObject {

    public string Alias { get; }

    public string? Title { get; }

    [MemberNotNullWhen(true, "Title")]
    public bool HasTitle => !string.IsNullOrWhiteSpace(Title);

    public string? Description { get; }

    [MemberNotNullWhen(true, "Description")]
    public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

    public string Authors { get; }

    public MarketplaceAuthorDetails? AuthorDetails { get; }

    [MemberNotNullWhen(true, "AuthorDetails")]
    public bool HasAuthorDetails => AuthorDetails is not null;

    public EssentialsTime LastPublished { get; }

    public string? IconUrl { get; }

    [MemberNotNullWhen(true, "IconUrl")]
    public bool HasIconUrl => !string.IsNullOrWhiteSpace(IconUrl);

    public long Downloads { get; }

    private MarketplacePackage(JObject json) : base(json) {
        Alias = json.GetString("packageId")!;
        Title = json.GetString("title");
        Description = json.GetString("description");
        Authors = json.GetString("authors")!;
        AuthorDetails = json.GetObject("authorDetails", MarketplaceAuthorDetails.Parse);
        LastPublished = json.GetString("lastPublishedOn", EssentialsTime.Parse)!;
        IconUrl = json.GetString("iconUrl");
        Downloads = json.GetInt64("numberOfNuGetDownloads");
    }

    public static MarketplacePackage Parse(JObject parse) {
        return new MarketplacePackage(parse);
    }

}