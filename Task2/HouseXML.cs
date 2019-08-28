using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task2
{
    [XmlRoot("XmlДом", ElementName = "Дом")]
    public class HouseXML
    {
        [XmlArray("комнатость квартир")]
        public int[] rooms;
        [XmlAttribute("этажность")]
        //[XmlIgnore]
        public int floors;
        [XmlElement("Количество этажей")]
        public int Floors
        {
            get { return floors; }
            set { floors = value; }
        }
        [XmlAttribute("Квартирность")]
        //[XmlIgnore]
        public int apartmens;
        [XmlElement("Количество квартир")]
        public int Apartmens { get { return apartmens; } set { apartmens = value; } }
        [XmlAttribute("название улицы")]
        public string StreetName;
        public string Rooms()
        {
            string str = null;
            foreach (var item in rooms)
            {
                str = str + " " + item.ToString() + ',';
            }
            return str;
        }
    }
}
