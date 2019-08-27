using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
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
            var inst = new MyClass();
            inst.i = 10;
            inst.Str = "какая-нить строка";
            var file = new FileInfo("Myclass.ins");
            FileStream fstream = file.Create();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fstream, inst);
            fstream.Close();
            inst.i = 100;
            inst.Str = "Другая строка";
            FileStream xmlfile = new FileStream("instance.xml", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            XmlSerializer xmlSerialazer = new XmlSerializer(typeof(MyClass));
            xmlSerialazer.Serialize(xmlfile, inst);
            fstream = file.Open(FileMode.Open);
            inst = formatter.Deserialize(fstream) as MyClass;
            xmlfile.Close();


            inst.Method();
            FileStream file1 = new FileStream("instance.xml", FileMode.Open);
            inst = xmlSerialazer.Deserialize(file1) as MyClass;
            inst.Method();
            xmlfile.Close();
            Console.WriteLine("Для выходп нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
