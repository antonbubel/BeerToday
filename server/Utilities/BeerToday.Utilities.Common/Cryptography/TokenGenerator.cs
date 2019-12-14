namespace BeerToday.Utilities.Common.Cryptography
{
    using System;
    using System.Security.Cryptography;

    /// <summary>
    /// Cryptographically secure token generator
    /// </summary>
    public static class TokenGenerator
    {
        /// <summary>
        /// Generates a cryptographically secure token using <see cref="RNGCryptoServiceProvider"/>
        /// </summary>
        /// <param name="tokenLength">Token length in bytes. Default length is defined in <see cref="Constants.DefaultTokenLength"/></param>
        /// <returns></returns>
        public static string Generate(int tokenLength = Constants.DefaultTokenLength)
        {
            var bytes = new byte[tokenLength];

            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(bytes);
            }

            return BitConverter.ToString(bytes)
                .Replace("-", string.Empty)
                .ToLower();
        }
    }
}
