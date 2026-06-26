using task03;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace task03tests;

public class IteratorTests
{
    // тест 1: проверяем, что обычный итератор работает
    [Fact]
    public void CustomCollection_GetEnumerator_ReturnsAllItems()
    {
        // готовим данные
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);

        // проходим по коллекции через foreach
        var result = new List<int>();
        foreach (var item in collection)
        {
            result.Add(item);
        }

        // проверяем, что получили все элементы
        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    // тест 2: обратный итератор
    [Fact]
    public void GetReverseEnumerator_ReturnsItemsInReverseOrder()
    {
        // готовим данные
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);

        // получаем элементы в обратном порядке
        var result = collection.GetReverseEnumerator().ToList();

        // проверяем
        Assert.Equal(new[] { 3, 2, 1 }, result);
    }

    // тест 3: генерация последовательности
    [Fact]
    public void GenerateSequence_ReturnsCorrectSequence()
    {
        // генерируем 3 числа начиная с 5
        var sequence = CustomCollection<int>.GenerateSequence(5, 3).ToList();

        // должно быть 5, 6, 7
        Assert.Equal(new[] { 5, 6, 7 }, sequence);
    }

    // тест 4: если count = 0, то ничего не возвращаем
    [Fact]
    public void GenerateSequence_ZeroCount_ReturnsEmpty()
    {
        var sequence = CustomCollection<int>.GenerateSequence(10, 0).ToList();
        Assert.Empty(sequence);
    }

    // тест 5: если count отрицательный, тоже ничего не возвращаем
    [Fact]
    public void GenerateSequence_NegativeCount_ReturnsEmpty()
    {
        var sequence = CustomCollection<int>.GenerateSequence(10, -5).ToList();
        Assert.Empty(sequence);
    }

    // тест 6: фильтрация и сортировка
    [Fact]
    public void FilterAndSort_ReturnsFilteredAndSortedItems()
    {
        // готовим коллекцию с числами
        var collection = new CustomCollection<int>();
        collection.Add(3);
        collection.Add(1);
        collection.Add(2);
        collection.Add(0);

        // фильтруем > 1, сортируем по возрастанию
        var result = collection.FilterAndSort(x => x > 1, x => x).ToList();

        // должно быть 2, 3
        Assert.Equal(new[] { 2, 3 }, result);
    }

    // Тест 7: фильтрация строк
[Fact]
    public void FilterAndSort_WithStrings_ReturnsFilteredAndSorted()
    {
        // готовим коллекцию со строками
        var collection = new CustomCollection<string>();
        collection.Add("Яблоко");
        collection.Add("Апельсин");
        collection.Add("Банан");
        collection.Add("Арбуз");

        // фильтруем слова длиной > 3, сортируем по алфавиту
        var result = collection.FilterAndSort(
            x => x.Length > 3,
            x => x
        ).ToList();

        // проверяем: все слова должны быть отсортированы по алфавиту
        Assert.Equal(new[] { "Апельсин", "Арбуз", "Банан", "Яблоко" }, result);
    }

    // тест 8: проверка удаления
    [Fact]
    public void Remove_RemovesItemFromCollection()
    {
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);

        // удаляем двойку
        bool removed = collection.Remove(2);

        // проверяем
        Assert.True(removed);
        var result = collection.GetAll();
        Assert.Equal(new[] { 1, 3 }, result);
    }

    // тест 9: проверка свойства Count
    [Fact]
    public void Count_ReturnsCorrectNumber()
    {
        var collection = new CustomCollection<int>();
        collection.Add(1);
        collection.Add(2);

        Assert.Equal(2, collection.Count);
    }

    // тест 10: проверка индексатора
    [Fact]
    public void Indexer_GetAndSet_WorksCorrectly()
    {
        var collection = new CustomCollection<string>();
        collection.Add("Первый");
        collection.Add("Второй");

        // получаем значение по индексу
        string first = collection[0];
        // меняем значение по индексу
        collection[1] = "Изменённый";

        Assert.Equal("Первый", first);
        Assert.Equal("Изменённый", collection[1]);
    }
}