using System.Globalization;
using System.Text.RegularExpressions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace IoC
{
    public class RouteCultureProvider : IRequestCultureProvider
    {
        private CultureInfo defaultCulture;
        private CultureInfo defaultUICulture;

        public RouteCultureProvider(RequestCulture requestCulture)
        {
            this.defaultCulture = requestCulture.Culture;
            this.defaultUICulture = requestCulture.UICulture;
        }

        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //Parsing language from url path, which looks like "/en/home/index"
            PathString url = httpContext.Request.Path;

            // Test any culture in route
            if (url.ToString().Length <= 1)
            {
                // Set default Culture and default UICulture
                return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(this.defaultCulture.ToString(), this.defaultUICulture.ToString()));
            }

            var parts = httpContext.Request.Path.Value.Split('/');
            var culture = parts[1];

            // Test if the culture is properly formatted
            if (!Regex.IsMatch(culture, @"^[a-z]{2}(-[A-Z]{2})*$"))
            {
                // Set default Culture and default UICulture
                return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(this.defaultCulture.ToString(), this.defaultUICulture.ToString()));
            }

            string uiculture = culture;

            switch (culture.ToLower())
            {
                case "ar":
                    culture += "-EG";
                    break;
                case "it":
                    culture += "-IT";
                    break;
                case "en":
                    culture += "-GB";
                    break;
                case "fr":
                    culture += "-FR";
                    break;
                default:
                    culture = "en-GB";
                    break;
            }
            // Set Culture and UICulture from route culture parameter
            return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(culture, uiculture));
        }
    }
}