 using System.Globalization;
 using Microsoft.AspNetCore.Builder;
 using Microsoft.AspNetCore.Http;

 public class CheckLanguage
    {
        private readonly RequestDelegate _next;

        public CheckLanguage(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                var headers = httpContext.Request.Headers;
                if (headers != null)
                {
                    var language = string.IsNullOrEmpty(headers["language"]) ? "en" : headers["language"].ToString();
                    if (language == "ar")
                    {
                        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ar-GB");
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ar-GB");
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-GB");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var cultureInfo = CultureInfo.CurrentCulture;
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckLanguageExtensions
    {
        public static IApplicationBuilder UseCheckLanguage(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckLanguage>();
        }
    }