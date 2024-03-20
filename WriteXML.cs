using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RPGWithXML
{
    public class WriteXML
    {
        public WriteXML() { }

        //USING LINQ TO XML
        public static void CreateXMLFile(string filePath, string name, int level, int health, int attack, int defense)
        {
            XDocument xmlDoc = new XDocument(
                new XElement("characters",
                    new XElement("character",
                        new XElement("name", name),
                        new XElement("level", level),
                        new XElement("health", health),
                        new XElement("attack", attack),
                        new XElement("defense", defense)
                    )
                )
            );

            filePath = "direccion path";
            xmlDoc.Save(filePath);

            Console.WriteLine("Documento XML creado correctamente.");
        }
    }
}
