using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Limbo.Integrations.Marketplace.Models.Packages;

public class MarketplacePackageList : MarketplaceObject {

    public IReadOnlyList<MarketplacePackage> Results { get; }

    private MarketplacePackageList(JObject json) : base(json) {
        Results = json.GetArrayItems("results", MarketplacePackage.Parse);
    }

    public static MarketplacePackageList Parse(JObject parse) {
        return new MarketplacePackageList(parse);
    }

}