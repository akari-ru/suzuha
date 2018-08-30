using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace suzuha.moth.FileTesting
{
    static class FileTesting
    {
        public static void Testing()
        {
            Console.WriteLine("File System Testing");
            Console.WriteLine("Testing Desktop directories and absolut path..");
            string path = @"C:\Users\akari\Desktop\";
            Console.WriteLine("path is " + path);
            DriveInfo driveInfo = new DriveInfo("C");
            Console.WriteLine("Current drive name is " + driveInfo.Name);
            Console.WriteLine("Current drive format is " + driveInfo.DriveFormat);
            Console.WriteLine("Current drive type is " + driveInfo.DriveType);
            Console.WriteLine("Current drive total size is " + driveInfo.TotalSize);

            Console.WriteLine("Directories at " + path);
            string[] desktopDirs = Directory.GetDirectories(path);
            int counter = 1;
            foreach (var entry in desktopDirs)
            {
                Console.Write(Convert.ToString(counter++) + ". " + Path.GetFileName(entry) + "\t");
            }
            Console.WriteLine();
            string empath = @".";
            Console.WriteLine("Absolut path of empty relativ path: " + Path.GetFullPath(empath));

            TestIOPathCreateDir();
            ObjectToXmlTest();
            string path2 = @"C:\\Users\akari\Desktop\otx_test.xml";
            var graph = ReadXmlToObjectGraph<List<PersonDataClassTest>>(path2);

            Console.WriteLine("Reading object graph from xml file:");
            foreach ( var person in graph)
            {
                Console.WriteLine(person.Name + " - " + person.Comment);
            }
            return;
        }

        private static void TestIOPathCreateDir()
        {
            string path = @"C:\\Users\akari\Desktop\testdir\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private static void ObjectToXmlTest()
        {
            string path = @"C:\\Users\akari\Desktop\otx_test.xml";

            List<PersonDataClassTest> objectGraph = new List<PersonDataClassTest>();
            objectGraph.Add(new PersonDataClassTest()
            {
                Name = "Selena",
                Comment = "Blue and innocent.",
                Id = 8
            });
            objectGraph.Add(new PersonDataClassTest()
            {
                Name = "Chou",
                Comment = "Kung Fu asian guy.",
                Id = 4
            });
            objectGraph.Add(new PersonDataClassTest()
            {
                Name = "Miya",
                Comment = "Bow and arrow are deeply linked to our inner souls.",
                Id = 1
            });

            var settings = new XmlWriterSettings() { Indent = true };
            using ( var xmlWriter = XmlWriter.Create(path, settings)) {
                var serializer = new DataContractSerializer(typeof(List<PersonDataClassTest>));
                serializer.WriteObject(xmlWriter, objectGraph);
            }
        }

        static void WriteObjectGraphToXml<T>(string path, T graph)
        {
            var settings = new XmlWriterSettings() { Indent = true };
            using (var xmlWriter = XmlWriter.Create(path, settings))
            {
                var serializer = new DataContractSerializer(typeof(List<PersonDataClassTest>));
                serializer.WriteObject(xmlWriter, graph);
            }
        }

        static T ReadXmlToObjectGraph<T>(string path)
        {
            var settings = new XmlReaderSettings();
            using (var xmlReader = XmlReader.Create(path, settings))
            {
                var serializer = new DataContractSerializer(typeof(List<PersonDataClassTest>));
                return (T) serializer.ReadObject(xmlReader);
            }
        }
    }
}
