using task07;
using Xunit;
using System.Reflection;

namespace task07tests;

public class AttributeTests
{
    // тест 1: проверка DisplayName у класса
    [Fact]
    public void ClassHasDisplayName()
    {
        var type = typeof(SampleClass);
        var attr = type.GetCustomAttribute<DisplayNameAttribute>();
        
        Assert.NotNull(attr);
        Assert.Equal("Пример класса", attr.DisplayName);
    }

    // тест 2: проверка DisplayName у метода
    [Fact]
    public void MethodHasDisplayName()
    {
        var method = typeof(SampleClass).GetMethod("TestMethod");
        var attr = method?.GetCustomAttribute<DisplayNameAttribute>();
        
        Assert.NotNull(method);
        Assert.NotNull(attr);
        Assert.Equal("Тестовый метод", attr.DisplayName);
    }

    // тест 3: проверка DisplayName у свойства
    [Fact]
    public void PropertyHasDisplayName()
    {
        var prop = typeof(SampleClass).GetProperty("Number");
        var attr = prop?.GetCustomAttribute<DisplayNameAttribute>();
        
        Assert.NotNull(prop);
        Assert.NotNull(attr);
        Assert.Equal("Числовое свойство", attr.DisplayName);
    }

    // тест 4: проверка Version у класса
    [Fact]
    public void ClassHasVersion()
    {
        var type = typeof(SampleClass);
        var attr = type.GetCustomAttribute<VersionAttribute>();
        
        Assert.NotNull(attr);
        Assert.Equal(1, attr.Major);
        Assert.Equal(0, attr.Minor);
        Assert.Equal("1.0", attr.GetVersionString());
    }

    // тест 5: проверка PrintTypeInfo
    [Fact]
    public void PrintTypeInfoTest()
    {
        var result = ReflectionHelper.PrintTypeInfo(typeof(SampleClass));
        
        Assert.Contains("Пример класса", result);
        Assert.Contains("Версия: 1.0", result);
        Assert.Contains("Тестовый метод", result);
        Assert.Contains("Числовое свойство", result);
    }

    // тест 6: проверка HasAttribute для класса
    [Fact]
    public void HasAttributeClassTest()
    {
        var result = ReflectionHelper.HasAttribute<DisplayNameAttribute>(typeof(SampleClass));
        Assert.True(result);
    }

    // тест 7: проверка HasAttribute для метода
    [Fact]
    public void HasAttributeMethodTest()
    {
        var method = typeof(SampleClass).GetMethod("TestMethod");
        var result = ReflectionHelper.HasAttribute<DisplayNameAttribute>(method);
        Assert.True(result);
    }

    // тест 8: проверка HasAttribute для свойства
    [Fact]
    public void HasAttributePropertyTest()
    {
        var prop = typeof(SampleClass).GetProperty("Number");
        var result = ReflectionHelper.HasAttribute<DisplayNameAttribute>(prop);
        Assert.True(result);
    }

    // тест 9: метод без атрибута
    [Fact]
    public void MethodWithoutAttribute()
    {
        var method = typeof(SampleClass).GetMethod("AnotherMethod");
        var attr = method?.GetCustomAttribute<DisplayNameAttribute>();
        Assert.Null(attr);
    }

    // тест 10: метод Add без атрибута
    [Fact]
    public void AddMethodWithoutAttribute()
    {
        var method = typeof(SampleClass).GetMethod("Add");
        var result = ReflectionHelper.HasAttribute<DisplayNameAttribute>(method);
        Assert.False(result);
    }

    // тест 11: проверка на null
    [Fact]
    public void PrintTypeInfoNullTest()
    {
        Assert.Throws<ArgumentNullException>(() => ReflectionHelper.PrintTypeInfo(null));
    }
}