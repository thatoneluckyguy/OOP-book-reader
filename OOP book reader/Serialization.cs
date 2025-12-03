using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static OOP_book_reader.Book;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP_book_reader
{
    public class Serialization : Iserialization
    {
        
        Book bok = new Book();
        XmlSerializer serializer = new XmlSerializer(typeof(Book));

        public void JSONser(Book bok, string Path)
        {
            string jsonString = JsonSerializer.Serialize(bok, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Path, jsonString);
        }

        public void XMLser(Book book, string Path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Book));

            using (FileStream fs = new FileStream(Path, FileMode.Create))
            {
                serializer.Serialize(fs, book);
            }
        }
    }
}
