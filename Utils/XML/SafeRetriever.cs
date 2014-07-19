using System;
using System.Xml.Linq;

namespace Utils.XML
{
    public class SafeRetriever
    {
        XElement xml;
        public SafeRetriever(XElement element)
        {
            xml = element;
        }

        public T Attribute<T>(string name)
        {
            var attrib = xml.Attribute(name);
            if (attrib == null)
                return default(T);

            return Fix<T>(attrib.Value);
        }
        public T Element<T>(string name)
        {
            var element = xml.Element(name);
            if (element == null)
                return default(T);

            if (typeof(T) == typeof(XElement))
                return (dynamic)element;
            return Fix<T>(element.Value);
        }

        T Fix<T>(string value)
        {
            dynamic ret = default(T);

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Boolean:
                    ret = Convert.ToBoolean(value);
                    break;
                case TypeCode.Int32:
                    ret = Convert.ToInt32(value);
                    break;
                case TypeCode.Single:
                    ret = Convert.ToSingle(value);
                    break;
                case TypeCode.String:
                    ret = value;
                    break;
            }

            return (T)ret;
        }
    }
}