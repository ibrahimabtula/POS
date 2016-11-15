using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace POS
{
    public static class ControlExtensions
    {
        public static void SaveLayout(this Component component, string uniqueName, object property)
        {
            if (component == null  || property == null) { return; }

            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Layouts"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Layouts");

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(property.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, property);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(AppDomain.CurrentDomain.BaseDirectory + "Layouts\\" + component.ToString() + "_" + uniqueName + ".xml");
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }

        }

        public static void LoadLayout<T>(this Component component, string uniqueName, string name)
        {
            if (component == null || name.Length == 0) { return; }

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Layouts"))
                return ;            

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "Layouts\\" + component.ToString() + "_" + uniqueName + ".xml");
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        T obj = (T)serializer.Deserialize(reader);
                        component.GetType().GetProperty(name).SetValue(component, obj);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
            }
        }
    }
}
