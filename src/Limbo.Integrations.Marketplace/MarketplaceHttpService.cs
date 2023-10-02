using System.Threading.Tasks;
using Limbo.Integrations.Marketplace.Options.Packages;
using Limbo.Integrations.Marketplace.Responses.Packages;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Marketplace {

    public class MarketplaceHttpService {

        public MarketplaceHttpClient Client { get; }

        public MarketplaceHttpService() {
            Client = new MarketplaceHttpClient();
        }

        /// <summary>
        /// Returns a list of packages matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance <see cref="MarketplacePagkageListResponse"/> representing the response from the API.</returns>
        public MarketplacePagkageListResponse GetPackages(MarketplaceGetPackagesOptions options) {
            return new MarketplacePagkageListResponse(Client.GetPackages(options));
        }

        public async Task<MarketplacePagkageListResponse> GetPackagesAsync(MarketplaceGetPackagesOptions options) {
            return new MarketplacePagkageListResponse(await Client.GetPackagesAsync(options));
        }

    }

}