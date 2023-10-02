using System;

namespace Limbo.Integrations.Marketplace.Exceptions;

/// <summary>
/// Class representing a basic Marketplace exception.
/// </summary>
public class MarketplaceException : Exception {

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public MarketplaceException(string message) : base(message) { }

}