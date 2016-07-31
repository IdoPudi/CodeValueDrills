using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class DynamicXElement : DynamicObject
    {
        private XElement _element;

        private DynamicXElement(XElement element)
        {
            _element = element;
        }

        public static dynamic Create(XElement element) => new DynamicXElement(element);
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool resultNotNull = false;
            //What happens if '_element.Element()' returns null?
            result = new DynamicXElement(_element.Element(binder.Name));

            if (result != null)
                resultNotNull = true;

            return resultNotNull;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            bool isValid = false;
            if (indexes.Length != 2 || typeof(string) != indexes[0].GetType() || typeof(int) != indexes[1].GetType())
                result = null;
            else
            {
                //What happens if '_element.Elements((string)indexes[0])' returns an empty collection?
                result = new DynamicXElement(_element.Elements((string)indexes[0]).ElementAt((int)indexes[1]));
                isValid = true;
            }
            return isValid;
        }

        public override string ToString() => _element.Value.ToString();

    }
}
