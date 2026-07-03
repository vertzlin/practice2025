using System;

namespace task07;

// вешаем атрибуты на класс
[DisplayName("Пример класса")]
[Version(1, 0)]
public class SampleClass
{
    // свойство с атрибутом
    [DisplayName("Числовое свойство")]
    public int Number { get; set; }

    // просто поле без атрибута
    public string SomeField;

    public SampleClass()
    {
        Number = 42;
        SomeField = "Привет";
    }

    // метод с атрибутом
    [DisplayName("Тестовый метод")]
    public void TestMethod()
    {
        Console.WriteLine("Тестовый метод вызван");
    }

    // метод без атрибута
    public void AnotherMethod()
    {
        Console.WriteLine("Другой метод");
    }

    // метод для тестов
    public int Add(int a, int b)
    {
        return a + b;
    }
}