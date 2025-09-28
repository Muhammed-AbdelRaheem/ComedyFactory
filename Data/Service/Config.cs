using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public static class Config
    {
        ////postgres DataBase

        //public static string Write_DefaultConnection { get; set; } = "Server=localhost;Port=5432;Database=ComedyFactoryWeb;User Id=postgres;Password=Admin@123";
        //public static string Read_DefaultConnection { get; set; } = "Server=localhost;Port=5432;Database=ComedyFactoryWeb;User Id=postgres;Password=Admin@123";


        //local
        public static string Write_DefaultConnection { get; set; } = "Server=.;DataBase=ComedyFactory;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        public static string Read_DefaultConnection { get; set; } = "Server=.;DataBase=ComedyFactory;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";


        ////live

        //public static string Write_DefaultConnection { get; set; } = "Server=db28009.public.databaseasp.net; Database=db28009; User Id=db28009; Password=T-b6nH7_+8fL; Encrypt=False; MultipleActiveResultSets=True;";
        //public static string Read_DefaultConnection { get; set; } = "Server=db28009.public.databaseasp.net; Database=db28009; User Id=db28009; Password=T-b6nH7_+8fL; Encrypt=False; MultipleActiveResultSets=True";


        public static string Placeholder { get; set; } = "images/front/placeholder.png";

        //local
        public static string AssetsDomain { get; set; } = "https://localhost:7133";

        //////live
        //public static string AssetsDomain { get; set; } = "http://comedyfacotryadminstrator.runasp.net/";


        public static string Assets { get; set; }
        public static string ImageflowS3Key { get; set; } = "/uploads/images/";
        public static string VideoBaseURLImg { get; set; } = "https://img.youtube.com/vi/";
        public static string VideoBaseURL { get; set; } = "https://www.youtube.com/watch?v=";
        public static string VideoURLEmbed { get; set; } = "https://www.youtube.com/embed/g8O3apaaw40?si=wShKdvn7sRa2eFL6 ";
        public static string WebSiteUrl { get; set; } = "https://admin.sauditheaters.com/";
        public static string ImageResizerAdmin { get; set; } = "?w=100&h=100&scale=both&mode=pad";
        public static string ImageResizerBox { get; set; } = "?w=600&h=600&scale=both&mode=pad";
        public static string ImageResizerBox_325 { get; set; } = "?w=325&h=325&scale=both&mode=pad&scale=both&mode=crop&bgcolor=white";
        public static string ImageResizerBanner { get; set; } = "?w=1920&scale=both&mode=pad";
        public static string PictureBaseURL { get; set; }
        public static string BaseURL { get; set; } = "https://.com";
        public static string DeletionRequestURL { get; set; } = $"{BaseURL}/en/account/fb/deletion?code=";
        //paytabs
        //public static string SuccessURL { get; set; } = "/Booking/PaymentDone/";
        //public static string IPNDomain { get; set; }
        //public static string PTPayUrl { get; set; }
        //public static string PTCurrency { get; set; }

        //public static string PayTabsProfileId { get; set; }
        //public static string PayTabsServerKey { get; set; }
        //public static string CallbackUrl { get; set; }

        //public static string IpnKey { get; set; } = "a0faab2a-6feb-416e-88e8-48bb6855c100";
        //public static string PTAddress { get; set; } = "address street";
        //public static string PTState { get; set; } = "01";
        //public static string PTZip { get; set; } = "12345";
        //public static string PTCountry { get; set; } = "SA";
        //public static string PTMobile { get; set; } = "0522222222";
        //public static string PTIP { get; set; } = "1.1.1.1";

        //public static string ReturnUrl { get; set; } = $"{SuccessURL}";
        public static string WebViewReturnUrlParam { get; set; } = "&WebView=true";



        public static string AdminUserId { get; set; } = "d21e21ed-c2d7-4c1f-a903-9dcfe4f9b3db";

        public static string Website { get; set; }
        public static string Schema { get; set; } = "https://";
        public static string JWTWebIssuer { get; set; }
        public static string JWTWebAudience { get; set; }
        public static string JWTWebKey { get; set; }

        public static string AppleSandboxSubscriptionURL { get; set; } = "api.storekit-sandbox.itunes.apple.com";
        public static string AppleSandboxVerifyReceiptURL { get; set; } = "sandbox.itunes.apple.com";

        public static string AppleSubscriptionURL { get; set; } = "api.storekit.itunes.apple.com";
        public static string AppleVerifyReceiptURL { get; set; } = "buy.itunes.apple.com";



        //private static void UpdateProperties(PipelineEnvironment environment = PipelineEnvironment.Local)
        //{
        //    switch (environment)
        //    {
        //        case PipelineEnvironment.Dev:


        //            break;

        //        case PipelineEnvironment.Stg:



        //            break;



        //        case PipelineEnvironment.Local:

        //            Environment = environment;
        //            AWSSNSARNAndroid = "arn:aws:sns:eu-central-1::app/GCM/android";
        //            AWSSNSARNIOS = "arn:aws:sns:eu-central-1::app/APNS/ios";
        //            Domain = "mtbcriyadh.com";
        //            TicketMX_API = $"https://devapi.{TicketMX_Domain}";
        //            Website = $"api-dev.{Domain}";
        //            JWTWebIssuer = Website;
        //            JWTWebAudience = Website;
        //            JWTWebKey = "29453559b5dbaV61f4V9ac335f9e89d8d321";
        //            API = $"https://api-dev.{Domain}";
        //            PictureBaseURL = $"{API}{ImageflowS3Key}";
        //            IPNDomain = API;
        //            CallbackUrl = $"PayTabsCallback?key={IpnKey}";
        //            PTPayUrl = "https://secure-egypt.paytabs.com";
        //            PTCurrency = "EGP";
        //            PayTabsProfileId = "77816";
        //            PayTabsServerKey = "SWJNWRTWN6-J2GKD2DLG6-DMZMZK2DDH";
        //            YearMin = 60;
        //            MonthMin = 5;
        //            BaseURL = "https://booking-dev.mtbcriyadh.com";
        //            DeletionRequestURL = $"{BaseURL}/en/account/fb/deletion?code=";
        //            Write_DefaultConnection = "Server=localhost;Port=5432;Database=ComedyFactory;User Id=postgres;Password=Admin@123";
        //            Read_DefaultConnection = "Server=localhost;Port=5432;Database=ComedyFactory;User Id=postgres;Password=Admin@123";
        //            AssetsDomain = "";
        //            Assets = "";
        //            AbsoluteExpiration = 30;
        //            SlidingExpiration = 30;
        //            break;
        //    }

        //}

        public static string? GetPictureBaseUrl(bool? apiAssets = false)
        {
            return apiAssets != null && apiAssets.Value ? PictureBaseURL : ImageflowS3Key;
        }

        public static string? GetWebViewRoute(bool? webView = false)
        {
            return webView != null && webView.Value ? WebViewReturnUrlParam : "";
        }


      
        public static List<string> HiddenUsers()
        {
            return new List<string>() { "494b2239-5bd6-45e0-a2e4-b1b36ffb18ef", "74e5ca29-0135-4d98-8160-2a51394c8cec", "1b2d7150-805c-4863-885d-eb19093979e4", "fa4973c0-54a9-4322-9f01-b19ea83cd530" };
        }


        public static string? GetIpAddress(IHttpContextAccessor _httpContextAccessor)
        {
            var ipAddress = string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"]) ? "0:0:0:1" :
                _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].ToString();
            return ipAddress;
        }

        public static string? GetUserId(IHttpContextAccessor _httpContextAccessor, UserManager<ApplicationUser> _userManager)
        {
            var updatedByUserId = _httpContextAccessor?.HttpContext?.User != null ? _userManager.GetUserId(_httpContextAccessor?.HttpContext?.User) ??
                                                                                    AdminUserId : AdminUserId;
            return updatedByUserId;
        }



        public static MemoryCacheEntryOptions GetCacheEntryOption(int second = 30)
        {
            return new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(second),
                SlidingExpiration = TimeSpan.FromSeconds(second),
                Size = 1024,
            };
        }


    }
    public class ImageResponse
    {
        public bool IsSuccess { get; set; }
        public string? Link { get; set; }
        public string? FileName { get; set; }
        public List<string>? Message { get; set; }
    }
}
