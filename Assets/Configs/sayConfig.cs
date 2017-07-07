using System;
using System.Collections.Generic;
using System.Xml;
namespace Configs {
    class sayConfig : CSLoader {
        private Dictionary<long, Dictionary<string, Value>> _items = new Dictionary<long, Dictionary<string, Value>>();
        public void Load(string xml) {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.Substring(1));
            XmlNode root = doc.LastChild;
            XmlNode key = root.FirstChild; // key
            while (key != null) {
                XmlNode value = key.NextSibling;
                Dictionary<string, Value> dict = new Dictionary<string, Value>();
                ParseDict(value.FirstChild, dict);
                _items.Add(long.Parse(key.InnerText), dict);
                key = value.NextSibling;
            }
        }
        Dictionary<long, Dictionary<string, Value>> Items { get { return _items; } }
    }
}