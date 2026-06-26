using task05;
using Xunit;
using System.Linq;

namespace task05tests;

public class ClassAnalyzerTests
{
    // тест 1: список публичных методов
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methods = analyzer.GetPublicMethods().ToList();

        Assert.Contains("Method", methods);
        Assert.Contains("Add", methods);
    }

    // тест 2: все поля включая приватные
    [Fact]
    public void GetAllFields_IncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var fields = analyzer.GetAllFields().ToList();

        Assert.Contains("_privateField", fields);
        Assert.Contains("PublicField", fields);
    }

    // тест 3: свойства
    [Fact]
    public void GetProperties_ReturnsProperties()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var properties = analyzer.GetProperties().ToList();

        Assert.Contains("Property", properties);
        Assert.Contains("Name", properties);
    }

    // тест 4: проверка атрибута (есть)
    [Fact]
    public void HasAttribute_WithAttribute_ReturnsTrue()
    {
        var analyzer = new ClassAnalyzer(typeof(AttributedClass));
        bool result = analyzer.HasAttribute<SerializableAttribute>();

        Assert.True(result);
    }

    // тест 5: проверка атрибута (нет)
    [Fact]
    public void HasAttribute_WithoutAttribute_ReturnsFalse()
    {
        var analyzer = new ClassAnalyzer(typeof(NonAttributedClass));
        bool result = analyzer.HasAttribute<SerializableAttribute>();

        Assert.False(result);
    }

    // тест 6: параметры метода
    [Fact]
    public void GetMethodParams_WithParameters_ReturnsCorrectInfo()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var result = analyzer.GetMethodParams("Add").ToList();

        Assert.Contains("Return: Int32", result);
    }

    // тест 7: проверка на null
    [Fact]
    public void Constructor_NullType_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new ClassAnalyzer(null));
    }
}