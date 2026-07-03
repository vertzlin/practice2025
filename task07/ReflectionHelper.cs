using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace task07;

public static class ReflectionHelper
{
    // главный метод - анализирует тип и выводит инфу
    public static string PrintTypeInfo(Type type)
    {
        // проверка на null
        if (type == null)
            throw new ArgumentNullException(nameof(type));

        // собираем вывод в StringBuilder
        var result = new StringBuilder();
        result.AppendLine($"=== Анализ класса: {type.Name} ===");

        // 1. проверяем DisplayName у класса
        var displayNameAttr = type.GetCustomAttribute<DisplayNameAttribute>();
        if (displayNameAttr != null)
        {
            result.AppendLine($"Отображаемое имя: {displayNameAttr.DisplayName}");
        }
        else
        {
            result.AppendLine("Отображаемое имя: не задано");
        }

        // 2. проверяем Version у класса
        var versionAttr = type.GetCustomAttribute<VersionAttribute>();
        if (versionAttr != null)
        {
            result.AppendLine($"Версия: {versionAttr.GetVersionString()}");
        }
        else
        {
            result.AppendLine("Версия: не задана");
        }

        // 3. собираем методы (только свои, без унаследованных)
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        if (methods.Length > 0)
        {
            result.AppendLine("\nМетоды:");
            foreach (var method in methods)
            {
                // смотрим есть ли атрибут у метода
                var methodDisplayName = method.GetCustomAttribute<DisplayNameAttribute>();
                string displayName = methodDisplayName != null ? methodDisplayName.DisplayName : "не задано";

                // параметры метода
                var parameters = method.GetParameters();
                string paramStr = "";
                if (parameters.Length > 0)
                {
                    var paramList = new List<string>();
                    foreach (var p in parameters)
                    {
                        paramList.Add($"{p.ParameterType.Name} {p.Name}");
                    }
                    paramStr = string.Join(", ", paramList);
                }
                else
                {
                    paramStr = "без параметров";
                }

                result.AppendLine($"  - {method.Name} ({paramStr})");
                result.AppendLine($"    Отображаемое имя: {displayName}");
            }
        }
        else
        {
            result.AppendLine("\nМетоды: нет");
        }

        // 4. собираем свойства
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        if (properties.Length > 0)
        {
            result.AppendLine("\nСвойства:");
            foreach (var prop in properties)
            {
                var propDisplayName = prop.GetCustomAttribute<DisplayNameAttribute>();
                string displayName = propDisplayName != null ? propDisplayName.DisplayName : "не задано";

                result.AppendLine($"  - {prop.Name} ({prop.PropertyType.Name})");
                result.AppendLine($"    Отображаемое имя: {displayName}");
            }
        }
        else
        {
            result.AppendLine("\nСвойства: нет");
        }

        // 5. поля (для полноты)
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        if (fields.Length > 0)
        {
            result.AppendLine("\nПоля (публичные):");
            foreach (var field in fields)
            {
                result.AppendLine($"  - {field.Name} ({field.FieldType.Name})");
            }
        }

        return result.ToString();
    }

    // проверка атрибута у типа
    public static bool HasAttribute<T>(Type type) where T : Attribute
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        return type.GetCustomAttribute<T>() != null;
    }

    // проверка атрибута у метода
    public static bool HasAttribute<T>(MethodInfo method) where T : Attribute
    {
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        return method.GetCustomAttribute<T>() != null;
    }

    // проверка атрибута у свойства
    public static bool HasAttribute<T>(PropertyInfo property) where T : Attribute
    {
        if (property == null)
            throw new ArgumentNullException(nameof(property));
        return property.GetCustomAttribute<T>() != null;
    }
}