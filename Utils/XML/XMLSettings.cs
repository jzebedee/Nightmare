using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Utils.XML
{
    public static class XMLSettings
    {
        public static void Save(ExpandoObject store, string filePath)
        {
            ExpandoToXML(store, "Settings").Save(filePath);
        }
        public static ExpandoObject Load(string filePath)
        {
            return File.Exists(filePath) ? XMLToExpando(XElement.Load(filePath)) : new ExpandoObject();
        }
        public static ExpandoObject Load(string filePath, out bool IsNew)
        {
            if (File.Exists(filePath))
            {
                IsNew = false;
                return XMLToExpando(XElement.Load(filePath));
            }
            else
            {
                IsNew = true;
                return new ExpandoObject();
            }
        }

        public static bool TryGet<T>(dynamic expando, string key, out T value)
        {
            object initValue;
            var result = (expando as IDictionary<string, object>).TryGetValue(key, out initValue);

            value = initValue != null ? (T)initValue : default(T);
            return result;
        }

        private static Dictionary<Type, XmlSerializer> TypedSerializers = new Dictionary<Type, XmlSerializer>();
        private static XmlSerializer GetSerializer(Type type)
        {
            XmlSerializer xS;

            lock (TypedSerializers)
            {
                if (!TypedSerializers.TryGetValue(type, out xS))
                {
                    xS = new XmlSerializer(type);
                    TypedSerializers[type] = xS;
                }
            }

            return xS;
        }

        public static XElement ExpandoToXML(dynamic node, String nodeName)
        {
            XElement xmlNode = new XElement(nodeName);

            foreach (var property in (node as IDictionary<String, Object>))
            {
                if (property.Value == null)
                    continue;

                if (property.Value.GetType() == typeof(ExpandoObject))
                    xmlNode.Add(ExpandoToXML(property.Value, property.Key));
                else
                {
                    var type = property.Value.GetType();
                    using (var xmlWriter = new StringWriter())
                    {
                        GetSerializer(type).Serialize(xmlWriter, property.Value);
                        var typedX = XElement.Parse(xmlWriter.ToString());
                        typedX.Name = property.Key;
                        typedX.SetAttributeValue("Type", type.FullName);
                        xmlNode.Add(typedX);
                    }
                }
            }
            return xmlNode;
        }

        private static Dictionary<string, Type> resolvedTypes = new Dictionary<string, Type>();
        public static ExpandoObject XMLToExpando(XElement xmlNode)
        {
            var expandoDict = new ExpandoObject() as IDictionary<string, object>;
            foreach (XElement node in xmlNode.Nodes())
            {
                var typeName = node.Attribute("Type").Value;
                var type = Type.GetType(typeName);

                bool complex = node.HasElements;

                if (type == null)
                {
                    lock (resolvedTypes)
                    {
                        if (!resolvedTypes.TryGetValue(typeName, out type))
                        {
                            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !(a.FullName.StartsWith("System.")));
                            foreach (var assembly in assemblies)
                            {
                                if (type != null)
                                    break;

                                type = assembly.GetTypes().Where(t => t.FullName == typeName).FirstOrDefault();
                            }

                            if (type != null)
                                resolvedTypes.Add(typeName, type);
                        }
                    }
                }

                object typedValue = null;
                if (type.BaseType == typeof(Enum))
                    typedValue = Enum.Parse(type, node.Value, true);
                else if (!complex)
                    typedValue = Convert.ChangeType(node.Value, type);
                else
                    using (var xmlReader = new StringReader(node.ToString()))
                        typedValue = Convert.ChangeType(GetSerializer(type).Deserialize(xmlReader), type);

                expandoDict.Add(node.Name.LocalName, typedValue);
            }

            return expandoDict as ExpandoObject;
        }
    }
}
