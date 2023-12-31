﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Limbo.Integrations.Marketplace.Models {

    /// <summary>
    /// Class representing a basic object from the Umbraco Marketplace API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class MarketplaceObject : JsonObjectBase {

        /// <summary>
        /// Gets the internal <see cref="Newtonsoft.Json.Linq.JObject"/> the object was created from.
        /// </summary>
        public new JObject JObject => base.JObject!;

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        public MarketplaceObject(JObject json) : base(json) { }

    }

}