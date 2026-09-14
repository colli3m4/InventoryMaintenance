using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using static InventoryMaintenance.frmNewItem;

namespace InventoryMaintenance
{
    public static class InvItemDB
    {
        private const string Path = @"InventoryItems.xml";

        public static List<InvItem> GetItems()
        {
            List<InvItem> items = new List<InvItem>();
            if (!File.Exists(Path))
            {
                return items;
            }
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };
            using (XmlReader xmlIn = XmlReader.Create(Path, settings))
            {
                if (xmlIn.ReadToDescendant("Item"))
                {

                    while (xmlIn.Read())
                    {

                        if (xmlIn.NodeType == XmlNodeType.Element && xmlIn.Name == "Item")
                        {
                            xmlIn.ReadStartElement("Item");
                            int itemNo = xmlIn.ReadElementContentAsInt();
                            string description = xmlIn.ReadElementContentAsString("Description", "");
                            decimal price = xmlIn.ReadElementContentAsDecimal("Price", "");

                            InvItem item = new InvItem(itemNo, description, price);
                            items.Add(item);


                        }

                    }

                }
                return items;
            }
        }
        public static void SaveItems(List<InvItem> items)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = " "
            };
            using (XmlWriter xmlOut = XmlWriter.Create(Path, settings))
            {
                xmlOut.WriteStartDocument();
                xmlOut.WriteStartElement("Items");

                foreach (InvItem item in items)
                {
                    xmlOut.WriteStartElement("Item");
                    xmlOut.WriteElementString("ItemNo", item.ItemNo.ToString());
                    xmlOut.WriteElementString("Description", item.Description);
                    xmlOut.WriteElementString("Price", item.Price.ToString());
                    xmlOut.WriteEndElement();

                }
                xmlOut.WriteEndElement();
                xmlOut.WriteEndDocument();
            }
        }
    }
}
    

               

