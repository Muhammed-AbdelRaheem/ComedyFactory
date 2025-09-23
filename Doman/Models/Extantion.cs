using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Domain.Models
{
    public static class Extantion
    {
        public static string TaskToken = "5fb76f6a-546b-47dc-adbc-";
        public static string TaskName = "Update_Requests";

        public static Func<List<int>, bool> MatchRate(int? rate = 0)
        {
            return e => (Math.Round(CalucRating(e.Sum(), e.Count)) == rate);
        }

        //public static Func<CartType, bool> CartTypeContain(string q)
        //{
        //    return e => (Enum.GetName(e).ToLower().Contains(q));
        //}

        public static decimal CalculatePriceWithTax(this decimal price, int tax)
        {
            double taxRate = (double)tax / 100;
            var res = decimal.Round(price + (price * (decimal)taxRate), 2, MidpointRounding.AwayFromZero);
            return res;
        }
        public static decimal CalculateTaxFromPriceWithTax(this decimal priceWithTax, int tax)
        {
            decimal taxRate = (decimal)tax / 100;
            var res = decimal.Round(priceWithTax - (priceWithTax / (1 + taxRate)), 2, MidpointRounding.AwayFromZero);
            return res;
        }
        public static decimal CalculatePriceWithDiscountPercent(this decimal price, decimal discount)
        {
            var res = discount / 100;
            return res <= 0 ? 0 : decimal.Round(price - (price * res), 2, MidpointRounding.AwayFromZero);
        }

        public static decimal CalculatePriceWithDiscount(this decimal price, decimal discount)
        {
            var res = price - discount;
            return res <= 0 ? 0 : decimal.Round(price - discount, 2, MidpointRounding.AwayFromZero);
        }

        public static CultureInfo GetCultureInfo(string code)
        {
            return new CultureInfo(code);
        }
        public static DateTime ToSaudiDate(this DateTime dateTime)
        {
            return dateTime.AddHours(3);
        }

        public static string ToUnixTimeMilliseconds(this DateTime dateTime)
        {

            DateTimeOffset dto = new DateTimeOffset(dateTime.ToUniversalTime());
            var date = dto.ToUnixTimeMilliseconds().ToString();
            return date;
        }

        public static DateTime AddUtcTime()
        {
            return DateTime.UtcNow;
   
        }



        public static string GetWebsiteYear(int startYear)
        {
            var currentYear = AddUtcTime().Year;
            if (startYear == currentYear)
            {
                return $"{currentYear}";

            }
            return $"{startYear} - {currentYear}";

        }
        public static string GetClientToken()
        {
            return Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
        }
        public static string GetClientId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        //public static bool UserInRole(this string userId, string roleId, IList<Role> roles, bool single)
        //{

        //    if (single == true)
        //    {
        //        var roleIds = roles.Where(s => s.UserId == userId).Select(s => s.RoleId).ToList();
        //        var isSingle = roleIds.Count == 1 && roleIds.Where(e => e == roleId).Any();
        //        return isSingle;
        //    }
        //    else
        //    {
        //        var roleIds = roles.Where(s => s.UserId == userId).Select(s => s.RoleId).ToList();
        //        var userRoleExist = roleIds.Where(e => e == roleId).Any();
        //        var rolesCount = roleIds.Count;
        //        var isSingle = (roleIds.Count > 1 || (rolesCount == 1 && !userRoleExist));
        //        return isSingle;
        //    }
        //}
        public static string GenerateToken()
        {
            int maxSize = 32;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return Convert.ToBase64String(data);
        }
        public static string RNGCharacterMask()
        {
            int maxSize = 15;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString();
        }

        public static List<DateTime> GetWeekdayInRange(DateTime today, DateTime from, DateTime to,
            DayOfWeek day, int durationBeforeOrder, DateTime timeFrom, bool allDay)
        {
            const int daysInWeek = 7;
            var result = new List<DateTime>();
            TimeSpan time = timeFrom.TimeOfDay;
            DateTime dateTodayWithTime = today.Date.Add(time);
            var daysToAdd = ((int)day - (int)from.DayOfWeek + daysInWeek) % daysInWeek;

            do
            {
                from = from.AddDays(daysToAdd);
                if (from.Date <= to.Date)
                {
                    if (from.Date == today.Date && (allDay || today <= dateTodayWithTime.AddHours(-durationBeforeOrder)))
                    {

                        result.Add(today);
                    }
                    else if (from.Date != today.Date && from.Date >= today.Date && (allDay || today <= from.Date.Add(time).AddHours(-durationBeforeOrder)))
                    {
                        result.Add(from);
                    }

                    daysToAdd = daysInWeek;
                }

            } while (from.Date < to.Date);
            return result;
        }

        // public static Func<DateTime,DateTime, bool, bool> IsBetween(int fixAllDat)
        // {
        //         return ((date,time, allDay) => date.Date.Add(time.TimeOfDay).AddHours(allDay ? 12 :0) >= DateTime.UtcNow.AddHours(3));
        // }
        //
        // public static Func<string, bool> IsBetweenStringNumber(double? Min, double? Max)
        // {
        //     Func<double?, bool> deleg = IsBetween(Min, Max);
        //     return e => deleg(double.Parse(Regex.Match(e, @"\d+").Value));
        // }
        //public static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        //{
        //    var json = JsonConvert.SerializeObject(obj);
        //    var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
        //    return dictionary;
        //}
        public class SerializeURLClientObject
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public static string SelectByLanguage(string language, string en, string ar, string fr)
        {

            if (language == "ar")
            {
                return ar;
            }
            else if (language == "en")
            {
                return en;
            }
            else if (language == "fr")
            {
                return fr;
            }
            else
            {
                return en;
            }
        }
        //public static T GetJson<T>(string obj)
        //{
        //    var dictionary = JsonConvert.DeserializeObject<T>(obj);
        //    return dictionary;
        //}

        public static string ConvertStringToEnum<T>(string status)
        {
            Enum name = (Enum)Enum.Parse(typeof(T), status);
            return name.DisplayName();
        }
        public static string ConvertHtmlToPlainTxt(string text)
        {
            return Regex.Replace(text, @"<(.|\n)*?>", "");
        }
        public static double? GetDiscount(this double? price, double? discount)
        {
            if (discount != null && discount > 0)
            {
                double? discounted_price = (price - (price * discount / 100));
                return discounted_price;

            }
            return price;
        }
        public static decimal VatPrice(decimal price, int vat)
        {
            return (price / 100) * vat;
        }
        public static double CalculateIncloudVat(double price, double vat)
        {
            double CR = (vat + 100) / 100;
            return price * CR;
        }
        public static decimal VatCost(decimal incVAT, int vat)
        {
            decimal cPrice = (decimal)(vat + 100) / 100;
            decimal tCost = incVAT * cPrice;
            return tCost - incVAT;
        }

        public static decimal GetPrice(decimal vat, decimal priceIncludeVat)
        {
            return priceIncludeVat - vat;
        }

        public static double? GetAmount(this double? price, double? discount)
        {
            if (discount != null && discount > 0)
            {
                double? discounted_price = (price * discount / 100);
                return discounted_price;
            }
            return price;
        }
        //public static HtmlString StringEnumDisplayNameFor(this Enum item)
        //{
        //    var type = item.GetType();
        //    var member = type.GetMember(item.ToString());
        //    CustomAttributeData displayName = (CustomAttributeData)member[0].CustomAttributes.FirstOrDefault();

        //    if (displayName != null)
        //    {
        //        return new HtmlString(displayName.ConstructorArguments.FirstOrDefault().Value.ToString());
        //    }

        //    return new HtmlString(item.ToString());
        //}

        //public static string GenerateAppleJwtToken(IConfiguration _configuration)
        //{


        //    var header = new Dictionary<string, object>()
        //    {
        //        { "alg", "ES256" },
        //        { "kid", "QB4U6Z3WYN" },
        //        { "typ", "JWT" }
        //    };

        //    var payload = new Dictionary<string, object>
        //    {
        //        { "iss", "69a6de90-d1f9-47e3-e053-5b8c7c11a4d1" },
        //        { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() },
        //        { "exp", DateTimeOffset.UtcNow.AddMinutes(15).ToUnixTimeSeconds() },
        //        { "aud", "appstoreconnect-v1" },
        //        { "bid", "sa.sela.datamx" }

        //    };
        //    var privateKey = _configuration["Authentication:Apple:TokenKey"];

        //    using (ECDsa key = ECDsa.Create())
        //    {
        //        key.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKey), out _);
        //        string token = JWT.Encode(payload, key, JwsAlgorithm.ES256, header);
        //        return token;

        //    }

        //    return null;
        //}


        public static string DisplayName(this Enum enuemValue)
        {
            return enuemValue.GetType()
                .GetMember(enuemValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
        }
        public static string GetDisplayName2(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attributes = field.GetCustomAttributes(
            typeof(DisplayAttribute), false) as DisplayAttribute[];

            return attributes == null ? value.ToString() :
                (attributes.Length > 0 ? attributes[0].GetName() : value.ToString());
        }
        //public static List<SelectListItem> ToSelectList<TEnum>(this TEnum obj) where TEnum : struct, IComparable, IFormattable, IConvertible
        //{
        //    return new SelectList(Enum.GetValues(typeof(TEnum))
        //    .OfType<Enum>()
        //    .Select(x => new SelectListItem
        //    {
        //        Text = Enum.GetName(typeof(TEnum), x),
        //        Value = (Convert.ToInt32(x))
        //        .ToString()
        //    }), "Value", "Text").ToList();
        //}


        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
        public static double CalucRating(int rateSum, int rateCount)
        {
            if (rateSum > 0 && rateCount > 0)
            {
                var ratingPercent = ((rateSum * 100) / rateCount) / 5;
                return (((double)ratingPercent / 100) * 5);
            }
            return 0;

        }


        public static string GenerateSignature(string passPhrase, Dictionary<string, string> data)
        {
            data.Remove("signature");
            var dataString = data.OrderBy(x => x.Key)
                .Select(x => $"{x.Key}={x.Value}")
                .Aggregate((x, y) => $"{x}{y}");

            var dataBytes = Encoding.UTF8.GetBytes($"{passPhrase}{dataString}{passPhrase}");
            var signature = SHA256.Create().ComputeHash(dataBytes);
            return BitConverter.ToString(signature).Replace("-", string.Empty).ToLower();
        }



        public static bool ValidateSignature(string signature, string passPhrase, Dictionary<string, string> data)
        {
            var generatedSignature = GenerateSignature(passPhrase, data);
            return signature == generatedSignature;
        }


        //public static FacebookDeleteAccountRequestData? GetUserData(string signed_request, string secretKey)
        //{
        //    var tokenParts = signed_request.Split('.').ToList();
        //    if (tokenParts.Count > 0)
        //    {
        //        string[] split = signed_request.Split('.');

        //        string signatureRaw = FixBase64String(split[0]);
        //        string dataRaw = FixBase64String(split[1]);

        //        byte[] signature = Convert.FromBase64String(signatureRaw);

        //        byte[] dataBuffer = Convert.FromBase64String(dataRaw);

        //        // JSON object
        //        string data = Encoding.UTF8.GetString(dataBuffer);

        //        // validate signature
        //        var hashedCode = GetHash(split[1], secretKey);
        //        var signatureString = BitConverter.ToString(signature).Replace("-", "").ToLower();
        //        return !hashedCode.Equals(signatureString) ? null : JsonConvert.DeserializeObject<FacebookDeleteAccountRequestData>(data);

        //    }
        //    return null;
        //}
        public static String GetHash(String text, String key)
        {
            // change according to your needs, an UTF8Encoding
            // could be more suitable in certain situations
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
        private static string FixBase64String(string str)
        {
            while (str.Length % 4 != 0)
            {
                str = str.PadRight(str.Length + 1, '=');
            }
            return str.Replace("-", "+").Replace("_", "/");
        }
    }

}
