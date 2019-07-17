using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace bilvideo.RazorHelpers
{
    public static class RazorHelper
    {
        public static MvcHtmlString EncodedLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            if (routeValues != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValues);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += "?";
                    }
                    else
                    {
                        queryString = "?";
                    }
                    queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                }
            }
            if (htmlAttributes != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    htmlAttributesString += " " + d.Keys.ElementAt(i) + "='" + d.Values.ElementAt(i) + "'";
                }
            }
            string link = Encrypt("/" + controllerName + "/" + actionName + "/" + queryString);
            link = "<a" + htmlAttributesString + " href='/watch?v=" + link + "'>" + linkText + "</a>";
            return new MvcHtmlString(link);
        }

        private static string Encrypt(string plainText)
        {
            string key = "bilvideo.com";
            byte[] EncryptKey = { };
            byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
            EncryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); byte[] inputByte = Encoding.UTF8.GetBytes(plainText);
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(EncryptKey, IV), CryptoStreamMode.Write);
            cStream.Write(inputByte, 0, inputByte.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
    }
}