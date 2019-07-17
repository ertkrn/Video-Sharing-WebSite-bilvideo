using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;//Add References -> Choose assemblies  
using System.Data;//Add  
using ForumErtkrn.Helper.External.Models; // Add  
using System.Xml;

namespace ForumErtkrn.Helper
{
    public class XMLReader
    {
        public List<Products> RetrunListOfProducts()
        {
            XmlTextReader reader = new XmlTextReader("http://rss.haberler.com/rss.asp?kategori=sondakika");
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(reader);
            var products = new List<Products>();
            products = (from Rows in ds.Tables[3].AsEnumerable()
                        select new Products
                        {
                            id = Rows[0].ToString(),
                            title = Rows[5].ToString(),
                            description = Rows[6].ToString(),
                            link = Rows[7].ToString(),
                            pubDate = Rows[8].ToString(),
                        }).ToList();
            return products;
        }
        public string ParseRssFile()
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("https://www.aksam.com.tr/cache/rss.xml");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssContent.Append("<a href='" + link + "'>" + title + "</a><br>" + description);
            }

            // Return the string that contain the RSS items
            return rssContent.ToString();
        }
    }
}
