using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using Task2;
using System.Runtime.Serialization.Formatters.Binary;
//Создайте новое приложение, в котором выполните
//десериализацию объекта из предыдущего примера.Отобразите
//состояние объекта на экране.
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\Task2\";
            Process.Start("explorer.exe",path);

            XmlSerializer serializer = new XmlSerializer(typeof(HouseXML));
            var houseXML = new HouseXML();
            var stream = new FileInfo(path+"House.xml");
            houseXML = (HouseXML)serializer.Deserialize(stream.Open(FileMode.Open, FileAccess.Read));
            Console.WriteLine("улица-{0} Кватрир-{1} этажей-{2} Комнатность{3}", houseXML.StreetName, houseXML.Apartmens, houseXML.Floors, houseXML.Rooms());
            Console.WriteLine(new string('-', 30));

            BinaryFormatter formatter = new BinaryFormatter();
            var file = File.OpenRead(path+ @"House.dat");
            var house = new House();
            house = formatter.Deserialize(file) as House;
            Console.WriteLine("{0} {1} {2}", house.StreetName, house.Floors, house.Apartmens);

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
