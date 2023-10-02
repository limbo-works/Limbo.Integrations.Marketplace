using System.Threading.Tasks;
using Limbo.Integrations.Marketplace.Options.Packages;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;

namespace Limbo.Integrations.Marketplace {

    public class MarketplaceHttpClient : HttpClient {

        public string Scheme => "https";

        public string Host => "api.marketplace.umbraco.com";

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {
            if (request.Url.StartsWith("/")) request.Url = $"{Scheme}://{Host}{request.Url}";
        }

        /// <summary>
        /// Returns a list of packages matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        public IHttpResponse GetPackages(MarketplaceGetPackagesOptions options) {
            return GetResponse(options);
        }

        public async Task<IHttpResponse> GetPackagesAsync(MarketplaceGetPackagesOptions options) {
            return await GetResponseAsync(options);
        }

    }


}