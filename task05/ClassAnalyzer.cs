using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace task05;

public class ClassAnalyzer
{
    private readonly Type _type;

    public ClassAnalyzer(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        _type = type;
    }

    // 1. Список публичных методов (без учёта унаследованных)
    public IEnumerable<string> GetPublicMethods()
    {
        // BindingFlags.DeclaredOnly - только методы, объявленные в этом классе
        return _type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Select(m => m.Name);
    }

    // 2. Параметры метода и возвращаемое значение
    public IEnumerable<string> GetMethodParams(string methodName)
    {
        var method = _type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        
        if (method == null)
            return Enumerable.Empty<string>();

        var result = new List<string>();

        // добавляем возвращаемый тип
        result.Add($"Return: {method.ReturnType.Name}");

        // добавляем параметры
        var parameters = method.GetParameters();
        if (parameters.Length == 0)
        {
            result.Add("Parameters: none");
        }
        else
        {
            var paramNames = string.Join(", ", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
            result.Add($"Parameters: {paramNames}");
        }

        return result;
    }

    // 3. Список всех полей (включая приватные)
    public IEnumerable<string> GetAllFields()
    {
        return _type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Select(f => f.Name);
    }

    // 4. Список свойств
    public IEnumerable<string> GetProperties()
    {
        return _type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Select(p => p.Name);
    }

    // 5. Проверка наличия атрибута
    public bool HasAttribute<T>() where T : Attribute
    {
        return _type.GetCustomAttribute<T>() != null;
    }
}