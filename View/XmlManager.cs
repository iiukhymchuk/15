using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace View
{
    class XmlManager
    {
        static string AppPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        static string FileName = Path.Combine(AppPath, "options.xml");

        internal static void Save(string mode, int size)
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", string.Empty),
                new XElement("options",
                    new XElement("mode", mode),
                    new XElement("size", size)));

            doc.Save(FileName);
        }

        internal static (string, int) Load()
        {
            try
            {
                XDocument doc = XDocument.Load(FileName);
                var mode = doc.Descendants().SingleOrDefault(p => p.Name.LocalName == "mode").Value;
                var size = doc.Descendants().SingleOrDefault(p => p.Name.LocalName == "size").Value;
                var isParsed = int.TryParse(size, out int sizeInt);

                if (isParsed && Helpers.IsValidMode(mode) && Helpers.IsValidSize(sizeInt))
                    return (mode, sizeInt);
            }
            catch (FileNotFoundException)
            {

            }

            return ("normal", 4);
        }
    }
}