using System;

namespace task05tests;

// Простой класс для тестирования
public class TestClass
{
    public int PublicField;
    private string _privateField;
    private int _privateIntField;
    protected string ProtectedField;
    internal string InternalField;

    public int Property { get; set; }
    public string Name { get; set; }
    private int PrivateProperty { get; set; }

    public void Method() { }

    public int Add(int a, int b) { return a + b; }

    public string Concat(string str1, string str2) { return str1 + str2; }

    public void VoidMethod() { }
}

// Класс с атрибутомa
[Serializable]
public class AttributedClass { }

// Класс без атрибутов
public class NonAttributedClass { }

// Класс с разными методами
public class MethodTestClass
{
    public void Method1() { }
    public void Method2(int x) { }
    public int Method3(string s, double d) { return 0; }
}