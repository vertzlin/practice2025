using System;

namespace task07;

// атрибут для отображаемого имени
// можно вешать на классы, методы и свойства
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
public class DisplayNameAttribute : Attribute
{
    // имя которое будем показывать
    public string DisplayName { get; }

    // конструктор - принимает имя
    public DisplayNameAttribute(string displayName)
    {
        DisplayName = displayName;
    }
}