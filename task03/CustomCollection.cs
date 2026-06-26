using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task03;

public class CustomCollection<T> : IEnumerable<T>
{
    // храню элементы в списке
    private readonly List<T> _items = new List<T>();

    // добавление
    public void Add(T item)
    {
        _items.Add(item);
    }

    // удаление по значению
    public bool Remove(T item)
    {
        return _items.Remove(item);
    }

    // удаление по индексу
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < _items.Count)
        {
            _items.RemoveAt(index);
        }
    }

    // количество элементов
    public int Count
    {
        get { return _items.Count; }
    }

    // индексатор - чтобы обращаться как к массиву
    public T this[int index]
    {
        get { return _items[index]; }
        set { _items[index] = value; }
    }

    // обычный итератор - просто отдаём итератор списка
    public IEnumerator<T> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    // не-generic версия (нужна для интерфейса IEnumerable)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // итератор для обратного обхода (шаг 5)
    // проходим с конца в начало и возвращаем элементы
    public IEnumerable<T> GetReverseEnumerator()
    {
        // начинаем с последнего элемента
        for (int i = _items.Count - 1; i >= 0; i--)
        {
            yield return _items[i];
        }
    }

    // генератор последовательности чисел (шаг 6)
    // статический метод, можно вызывать без создания объекта
    public static IEnumerable<int> GenerateSequence(int start, int count)
    {
        // если передали 0 или отрицательное число - выходим
        if (count <= 0)
        {
            yield break;  // это типа "стоп, ничего не возвращаем"
        }

        // генерируем числа: start, start+1, start+2, ...
        for (int i = 0; i < count; i++)
        {
            yield return start + i;
        }
    }

    // фильтрация + сортировка через LINQ (шаг 7)
    // принимаем: условие фильтрации и ключ для сортировки
    public IEnumerable<T> FilterAndSort(Func<T, bool> predicate, Func<T, IComparable> keySelector)
    {
        // сначала фильтруем
        var filtered = _items.Where(predicate);
        // потом сортируем
        var sorted = filtered.OrderBy(keySelector);
        // возвращаем результат
        return sorted;
    }

    // для удобства тестирования - получаем все элементы списком
    public List<T> GetAll()
    {
        // возвращаем копию, чтобы внешний код не менял наш внутренний список
        return new List<T>(_items);
    }
}