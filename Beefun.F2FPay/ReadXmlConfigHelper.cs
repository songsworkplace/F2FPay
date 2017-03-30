using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Beefun.F2FPay.AliPay;

namespace Beefun.F2FPay
{
    public class ReadXmlConfigHelper
    {
        private static string filePath = string.Format(@"{0}bin\alipayconfig.xml", AppDomain.CurrentDomain.BaseDirectory);

        public ReadXmlConfigHelper(string fileName)
        {
            filePath = string.Format(@"{0}bin\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
        }
        public DateTime ConfigTime { get { return GetFileCreateTime(); } }
        public Dictionary<string, string> ReadXmlConfig()
        {
            //NameValueCollection collection = new NameValueCollection();
            Dictionary<string, string> dics = new Dictionary<string, string>();
            try
            {

                if (File.Exists(filePath))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePath);
                    XmlElement root = doc.DocumentElement;
                    if (root != null)
                    {
                        var nodes = root.ChildNodes;
                        foreach (XmlNode node in nodes)
                        {
                            if (!node.Name.Contains("#comment"))
                            {
                                var innerText = node.InnerText;
                                if (!string.IsNullOrEmpty(innerText))
                                {
                                    innerText = innerText.Replace("\r", "");
                                    innerText = innerText.Replace("\n", "");
                                    //collection.Add(node.Name, innerText);
                                    dics.Add(node.Name, innerText);
                                }
                                else if (node.Attributes != null && !string.IsNullOrEmpty(node.Attributes["value"].Value))
                                {
                                    //collection.Add(node.Name, node.Attributes["value"].Value);
                                    dics.Add(node.Name, node.Attributes["value"].Value);
                                }
                                
                            }
                        }
                    }
                }
                return dics;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public  DateTime GetFileCreateTime()
        {
            FileInfo file = new FileInfo(filePath);
            return file.CreationTime;
        }
    }
}
