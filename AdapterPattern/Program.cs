using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class DocReader
    {
        string _file;
        public DocReader(string file)
        {
            try
            {
                if (!file.Contains(".doc"))
                    throw new FormatException("Ошибка! Формат файла не соответствует");

                _file = file;
                Console.WriteLine($"Открытие файла: {_file}");
            } catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadFile()
        {
            if (_file != null)
            {
                Console.WriteLine($"Чтение файла {_file}");
                Console.WriteLine("Закрытие файла");
            }
        }
    }

    class DocFileAdapter
    {
        string _file;
        DocReader _reader;
        
        public DocFileAdapter(string file)
        {
            // конвертируем файл
            Console.WriteLine($"Конвертируев файл {file} в .doc");
            _file = file.Replace(".txt", ".doc");
            Console.WriteLine($"Создаем DocReader  с новым файлом {_file}");
            _reader = new DocReader(_file);
        }

        public DocReader GetDocReader()
        {
            return _reader;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // имеет файл, отличный от формата .doc
            // с .txt будет ошибка
            string file = "MyFile.txt";

            DocReader reader = new DocReader(file);
            reader.ReadFile();
            Console.WriteLine();
            // применяем адаптер для открытия файла
            reader = new DocFileAdapter(file).GetDocReader();
            reader.ReadFile();

            Console.Read();
        }
    }
}
