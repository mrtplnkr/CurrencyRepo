using System.Xml.Linq;
using System.Xml.Serialization;

namespace CubeExample
{
    public static class XmlExtensions
    {
        public static T DeserializeWithoutEnvelope<T>(this string xml, string namespaceUri, string rootElementName)
        {
            // Load the XML into an XDocument
            XDocument document = XDocument.Parse(xml);

            // Define the namespace
            XNamespace ns = namespaceUri;

            // Extract the root element within the namespace
            XElement rootElement = document.Root.Element(ns + rootElementName);

            // Convert the root element back to an XML string
            string rootXml = rootElement.ToString();

            // Deserialize the root XML string
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootElementName)
            {
                Namespace = namespaceUri
            });

            using (StringReader reader = new StringReader(rootXml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
