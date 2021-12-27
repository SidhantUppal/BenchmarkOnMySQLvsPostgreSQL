using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MySQLVSPostgresWithReact.Logs
{
    public class LoggedXML
    {
        public static void LoggedInXML(string error)
        {
            if (!File.Exists("Logged.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("Logged.xml"))
                {
                    writer.WriteStartElement("ErrorList");
                    writer.WriteElementString("error", error);
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }

            else
            {
                // creating object of XML DOCument class  
                XmlDocument XmlDocObj = new XmlDocument();
                //loading XML File in memory  
                XmlDocObj.Load("Logged.xml");
                //Select root node which is already defined  
                XmlNode RootNode = XmlDocObj.SelectSingleNode("ErrorList");
                //Creating one child node with tag name book  
                XmlNode bookNode = RootNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "error", ""));
                //adding node title to book node and inside it data taking from tbTitle TextBox  

                bookNode.AppendChild(XmlDocObj.CreateNode(XmlNodeType.Element, "Title", "")).InnerText = error;

                //after adding node, saving BookStore.xml back to the server  
                XmlDocObj.Save("Logged.xml");
            }
        }
    }
}
