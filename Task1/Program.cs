using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
//Создайте пользовательский тип(например, класс)
//и выполните сериализацию объекта этого типа, учитывая
//тот факт, что состояние объекта необходимо будет передать по сети.

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание объекта типа MyClass
            var inst = new MyClass();
            //Заполнение полей
            inst.fieldInt = 1;
            inst.propertyString = "сеариализция в бинарном формате";
            //Создаем обект класса FileInfo служащий оболочкой для файла
            var file = new FileInfo("instance");
            //Создаем файл
            FileStream fstream = file.Create();
            //Создаем форматтер в бинарном формате
            BinaryFormatter formatter = new BinaryFormatter();
            //Сериализуем объект inst в поток fstream
            formatter.Serialize(fstream, inst);
            //Закрываем поток
            fstream.Close();

            //Задаем новые значения полей
            inst.fieldInt = 2;
            inst.propertyString = "сеариализция в XML формате";
            //Создаем обект класса FileInfo служащий оболочкой для файла и передаем его в поток
            //Тоже самое что и с предыдущем файлом но другим способом
            FileStream xmlfile = new FileStream("instance.xml", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            //Создаем форматтер в XML формате
            XmlSerializer xmlSerialazer = new XmlSerializer(typeof(MyClass));
            //Сериализуем объект inst в поток xmlfile
            xmlSerialazer.Serialize(xmlfile, inst);
            //Закрываем поток
            xmlfile.Close();

            //Открываем файл с адресом хранящиимся в file типа FileInfo и передаем содержимое в поток fstream
            fstream = file.Open(FileMode.Open);
            //Десериализуем из потока fstream в объект inst Binary-форматером
            inst = formatter.Deserialize(fstream) as MyClass;
            //Закрываем поток
            xmlfile.Close();
            //Вызаваем метод
            inst.Method();

            //Открываем файл instance.xml и передаем содержимое в поток MyFile
            FileStream myFile = new FileStream("instance.xml", FileMode.Open);
            //Десериализуем из потока myFile в объект inst Xml-форматером
            inst = xmlSerialazer.Deserialize(myFile) as MyClass;
            //Вызаваем метод
            inst.Method();
            //Закрываем поток
            xmlfile.Close();

            Console.WriteLine("Для выходп нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
