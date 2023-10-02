using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Limbo.Integrations.Marketplace.Models.Authors;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

#pragma warning disable CS1591

namespace Limbo.Integrations.Marketplace.Models.Packages;

public class MarketplacePackage : MarketplaceObject {

    public Guid Id { get; }

    public string Alias { get; }

    public string? Title { get; }

    [MemberNotNullWhen(true, "Title")]
    public bool HasTitle => !string.IsNullOrWhiteSpace(Title);

    public string? Description { get; }

    [MemberNotNullWhen(true, "Description")]
    public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

    public string? Authors { get; }

    [MemberNotNullWhen(true, "Authors")]
    public bool HasAuthors => !string.IsNullOrWhiteSpace(Authors);

    public MarketplaceAuthorDetails? AuthorDetails { get; }

    [MemberNotNullWhen(true, "AuthorDetails")]
    public bool HasAuthorDetails => AuthorDetails is not null;

    public EssentialsTime LastPublished { get; }

    public string? IconUrl { get; }

    [MemberNotNullWhen(true, "IconUrl")]
    public bool HasIconUrl => !string.IsNullOrWhiteSpace(IconUrl);

    public long? NumberOfNuGetDownloads { get; }

    [MemberNotNullWhen(true, "NumberOfNuGetDownloads")]
    public bool HasNumberOfNuGetDownloads => NumberOfNuGetDownloads is not null;

    public string? PackageType { get; }

    public IReadOnlyList<string> LicenseTypes { get; }

    public string? IconDominantColor { get; }

    public bool? IsPromoted { get; }

    public bool? IsPartner { get; }

    public bool? IsHq { get; }

    public bool? IsHqSupported { get; }

    public string? MinimumUmbracoVersionNumber { get; }

    public string? MaximumUmbracoVersionNumber { get; }

    public bool? MaximumUmbracoVersionNumberIsInclusive { get; }

    public string PackageId { get; }

    public IReadOnlyList<string> Tags { get; }

    public IReadOnlyList<int> UmbracoMajorVersionsSupported { get; }

    private MarketplacePackage(JObject json) : base(json) {
        Id = json.GetGuid("id");
        Alias = json.GetString("packageId")!;
        Title = json.GetString("title");
        Description = json.GetString("description");
        Authors = json.GetString("authors")!;
        AuthorDetails = json.GetObject("authorDetails", MarketplaceAuthorDetails.Parse);
        LastPublished = json.GetString("lastPublishedOn", EssentialsTime.Parse)!;
        IconUrl = json.GetString("iconUrl");
        NumberOfNuGetDownloads = json.GetInt64OrNull("numberOfNuGetDownloads");
        PackageType = json.GetString("packageType");
        LicenseTypes = json.GetStringArray("licenseTypes");
        IconDominantColor = json.GetString("iconDominantColor");
        IsPromoted = json.GetBooleanOrNull("isPromoted");
        IsPartner = json.GetBooleanOrNull("isPartner");
        IsHq = json.GetBooleanOrNull("isHQ");
        IsHqSupported = json.GetBooleanOrNull("isHQSupported");
        MinimumUmbracoVersionNumber = json.GetString("minimumUmbracoVersionNumber");
        MaximumUmbracoVersionNumber = json.GetString("maximumUmbracoVersionNumber");
        MaximumUmbracoVersionNumberIsInclusive = json.GetBooleanOrNull("maximumUmbracoVersionNumberIsInclusive");
        PackageId = json.GetString("packageId")!;
        Tags = json.GetStringArray("tags");
        UmbracoMajorVersionsSupported = json.GetInt32Array("umbracoMajorVersionsSupported");
    }

    public static MarketplacePackage Parse(JObject parse) {
        return new MarketplacePackage(parse);
    }

}