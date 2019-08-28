using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Xml.Serialization;
//Создайте класс, поддерживающий сериализацию.Выполните сериализацию объекта этого класса в формате XML.
//Сначала используйте формат по умолчанию, а затем измените его таким образом, чтобы значения полей
//сохранились в виде атрибутов элементов XML.
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\";
            Process.Start("explorer.exe", path);

            House house = new House();
            house.Apartmens = 40;
            house.Floors = 3;
            house.StreetName = "Рогачевская 18";            
            var file = new FileStream(path+"House.dat", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
            formatter.Serialize(file, house);
            file.Close();


            HouseXML houseXML = new HouseXML();
            houseXML.Apartmens = 100;
            houseXML.Floors = 5;
            houseXML.StreetName = "Ветковская";
            houseXML.rooms = new int[] { 1, 2, 3, 4 };
            XmlSerializer xml = new XmlSerializer(typeof(HouseXML));
            file = new FileStream(path+"House.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            xml.Serialize(file, houseXML);
            file.Close();

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
