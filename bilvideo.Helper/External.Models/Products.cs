using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ForumErtkrn.Helper.External.Models
{
    [Serializable]
    [XmlRoot("Products"),XmlType("Products")]
    public class Products
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
    }
}
