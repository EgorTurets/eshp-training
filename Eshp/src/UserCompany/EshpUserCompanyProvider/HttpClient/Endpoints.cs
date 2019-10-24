using System;

namespace EshpUserCompanyProvider.HttpClient
{
    internal static class Endpoints
    {
        private const string productPath = "/product";

        internal static Uri GetProductBase(int id)
        {
            var relativeUri = new Uri($"{productPath}/base/{id}", UriKind.Relative);
            return relativeUri;
        }

        internal static Uri GetProduct(int id)
        {
            return new Uri($"{productPath}/{id}", UriKind.Relative);
        }
    }
}
