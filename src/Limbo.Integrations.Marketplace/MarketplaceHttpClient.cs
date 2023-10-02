using System.Threading.Tasks;
using Limbo.Integrations.Marketplace.Options;
using Limbo.Integrations.Marketplace.Options.Packages;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;

namespace Limbo.Integrations.Marketplace {

    /// <summary>
    /// Clients for making HTTP based requests to the Umbraco Marketplace API.
    /// </summary>
    /// <see cref="https://api.marketplace.umbraco.com/index.html"/>
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

        /// <summary>
        /// Returns a list all available Umbraco minor versions since Umbraco 8.
        /// </summary>
        /// <returns>An instance <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        public IHttpResponse GetUmbracoVersions() {
            return GetUmbracoVersions(new MarketplaceGetUmbracoVersionsOptions());
        }

        /// <summary>
        /// Returns a list all available Umbraco minor versions since Umbraco 8.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        public IHttpResponse GetUmbracoVersions(MarketplaceGetUmbracoVersionsOptions options) {
            return GetResponse(options);
        }

        /// <summary>
        /// Returns a list all available Umbraco minor versions since Umbraco 8.
        /// </summary>
        /// <returns>An instance <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        public async Task<IHttpResponse> GetUmbracoVersionsAsync() {
            return await GetUmbracoVersionsAsync(new MarketplaceGetUmbracoVersionsOptions());
        }

        /// <summary>
        /// Returns a list all available Umbraco minor versions since Umbraco 8.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance <see cref="IHttpResponse"/> representing the raw response from the API.</returns>
        public async Task<IHttpResponse> GetUmbracoVersionsAsync(MarketplaceGetUmbracoVersionsOptions options) {
            return await GetResponseAsync(options);
        }

    }

}