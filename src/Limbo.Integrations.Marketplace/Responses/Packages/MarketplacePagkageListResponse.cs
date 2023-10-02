using Limbo.Integrations.Marketplace.Models.Packages;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Marketplace.Responses.Packages {

    /// <summary>
    /// Class representing a response with a list of packages.
    /// </summary>
    public class MarketplacePagkageListResponse : MarketplaceResponse<MarketplacePackageList> {

        public MarketplacePagkageListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, MarketplacePackageList.Parse);
        }

    }

}