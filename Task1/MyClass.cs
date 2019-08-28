using System;
using System.Xml.Serialization;

namespace Task1
{
    [Serializable]
    public class MyClass
    {
        /// <summary>
        /// Закрытое строковое поле
        /// </summary>
        string fieldString;
        /// <summary>
        /// Открытое целочисленное поле
        /// </summary>
        [XmlElement(ElementName = "Числовое поле")]
        public int fieldInt;
        /// <summary>
        /// Открытое строковое свойство
        /// </summary>
        [XmlElement(ElementName = "Строковое поле")]
        public string propertyString
        {
            get { return fieldString; }
            set { fieldString = value; }
        }
        //Открытый конструктор без параметров
        public MyClass()
        {

        }
        /// <summary>
        /// Открытый метод ничего не возвращает выводит значения полей объекта
        /// </summary>
        public void Method()
        {
            Console.WriteLine("Значение целочисленного поля: "+fieldInt + "  строкового поля: " + fieldString);
        }
    }
}
