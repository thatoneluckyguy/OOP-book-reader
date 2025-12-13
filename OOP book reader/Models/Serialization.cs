using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using static OOP_book_reader.Models.Book;

namespace OOP_book_reader.Models
{
    public class Serialization : Iserialization
    {
        public void JSONserList(List<Book> books, string path)
        {
            string jsonString = JsonSerializer.Serialize(
                books,
                new JsonSerializerOptions { WriteIndented = true }
            );

            File.WriteAllText(path, jsonString);
        }

        public void XMLserList(List<Book> books, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, books);
            }
        }


        public void JSONser(Book book, string path)
        {
            string jsonString = JsonSerializer.Serialize(book, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }

        public void XMLser(Book book, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Book));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, book);
            }
        }
    }
}
