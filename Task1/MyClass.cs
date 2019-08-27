using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class MyClass
    {
        string str;
        [XmlElement(ElementName = "Числовое поле")]
        public int i;
        [XmlElement(ElementName = "Строковое поле")]
        public string Str
        {
            get { return str; }
            set { str = value; }
        }
        public MyClass()
        {

        }
        public void Method()
        {
            Console.WriteLine(i + str);
        }
    }
}
