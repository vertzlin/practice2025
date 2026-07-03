using System;

namespace task07;

// атрибут для версии класса
// только для классов
[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute : Attribute
{
    // основные и минорные номера
    public int Major { get; }
    public int Minor { get; }

    public VersionAttribute(int major, int minor)
    {
        Major = major;
        Minor = minor;
    }

    // строковое представление версии
    public string GetVersionString()
    {
        return $"{Major}.{Minor}";
    }
}