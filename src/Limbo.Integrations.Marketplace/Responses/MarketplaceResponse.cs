using System.Net;
using Limbo.Integrations.Marketplace.Exceptions;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Marketplace.Responses {

    /// <summary>
    /// Class representing a response from the Umbraco Marketplace API.
    /// </summary>
    public class MarketplaceResponse : HttpResponseBase {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public MarketplaceResponse(IHttpResponse response) : base(response) {
            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.Created) return;
            throw new MarketplaceHttpException(response);
        }

    }

    /// <summary>
    /// Class representing a response from the Umbraco Marketplace API.
    /// </summary>
    public class MarketplaceResponse<T> : MarketplaceResponse {

        /// <summary>
        /// /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; } = default!;

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public MarketplaceResponse(IHttpResponse response) : base(response) { }

    }

}