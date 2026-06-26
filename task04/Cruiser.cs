using System;

namespace task04;

// Крейсер - медленный, но мощный
public class Cruiser : ISpaceship
{
    // текущее состояние корабля
    private int _angle = 0;      // угол поворота (0-359)
    private int _position = 0;   // условная позиция на прямой

    // характеристики (только для чтения)
    public int Speed => 50;      // крейсер медленный
    public int FirePower => 100; // но мощный

    // двигаемся вперёд с учётом скорости
    public void MoveForward()
    {
        _position += Speed;
        Console.WriteLine($"Крейсер движется вперёд. Позиция: {_position}");
    }

    // поворачиваем на заданный угол
    public void Rotate(int angle)
    {
        // прибавляем угол и нормализуем в диапазон 0-359
        _angle = (_angle + angle) % 360;
        if (_angle < 0)
        {
            _angle += 360;
        }
        Console.WriteLine($"Крейсер повернут на угол: {_angle} градусов");
    }

    // стреляем
    public void Fire()
    {
        Console.WriteLine($"Крейсер стреляет! Мощность: {FirePower}. Ба-БАХ!");
    }

    // эти методы добавил для тестов, чтобы проверять состояние
    public int GetPosition() => _position;
    public int GetAngle() => _angle;
}