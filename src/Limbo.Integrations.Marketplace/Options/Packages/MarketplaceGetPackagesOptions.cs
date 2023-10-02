using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;

namespace Limbo.Integrations.Marketplace.Options.Packages {

    /// <summary>
    /// Class representing the options for a request for getting a list of packages.
    /// </summary>
    public class MarketplaceGetPackagesOptions : IHttpRequestOptions {

        /// <summary>
        /// Gets or sets the text to search for.
        /// </summary>
        public string? Text { get; set; }

        public MarketplacePackageSortField? OrderBy { get; set; }

        public string? Fields { get; set; }

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            IHttpQueryString query = new HttpQueryString();
            if (!string.IsNullOrWhiteSpace(Text)) query.Add("text", Text!);
            if (OrderBy is not null) query.Add("orderBy", OrderBy.Value.ToPascalCase());
            if (!string.IsNullOrWhiteSpace(Fields)) query.Add("fields", Fields!);
            if (PageSize is not null) query.Add("pageSize", PageSize);
            if (PageNumber is not null) query.Add("pageNumber", PageNumber);

            return HttpRequest.Get("/api/v1.0/packages", query);

        }

    }
}