using System;

//объявляем пространство имен на весь файл без использования фигурных скобок
namespace CSharpPlayground.Features;

public class FileScopedNamespace
{
    public static void Run()
    {
        Console.WriteLine("Hello from FileScopedNamespace!");
    }

    public class Address
    {
        public required string Street { get; set; }
    }
}
