using System;

namespace task04;

// Истребитель - быстрый, но слабый
public class Fighter : ISpaceship
{
    private int _angle = 0;
    private int _position = 0;

    // характеристики
    public int Speed => 100;     // истребитель быстрый
    public int FirePower => 30;  // но стреляет слабо

    public void MoveForward()
    {
        _position += Speed;
        Console.WriteLine($"Истребитель летит вперёд. Позиция: {_position}");
    }

    public void Rotate(int angle)
    {
        _angle = (_angle + angle) % 360;
        if (_angle < 0)
        {
            _angle += 360;
        }
        Console.WriteLine($"Истребитель повернут на угол: {_angle} градусов");
    }

    public void Fire()
    {
        Console.WriteLine($"Истребитель стреляет! Мощность: {FirePower}. Пью-Пью!");
    }

    // для тестов
    public int GetPosition() => _position;
    public int GetAngle() => _angle;
}