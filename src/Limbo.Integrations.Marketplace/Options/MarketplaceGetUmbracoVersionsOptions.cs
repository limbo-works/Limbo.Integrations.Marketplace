using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Marketplace.Options {

    /// <summary>
    /// Options class for getting a list of Umbraco version.
    /// </summary>
    public class MarketplaceGetUmbracoVersionsOptions : IHttpRequestOptions {

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            return HttpRequest.Get("/api/v1.0/umbracoversions");
        }

    }

}