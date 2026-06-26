using System;

namespace task04;

// Интерфейс для всех космических кораблей
// Все корабли должны уметь двигаться, поворачиваться и стрелять
public interface ISpaceship
{
    void MoveForward();      // Движение вперёд
    void Rotate(int angle);  // Поворот на угол (градусы)
    void Fire();             // Выстрел
    int Speed { get; }       // Скорость корабля (разная у разных типов)
    int FirePower { get; }   // Мощность выстрела (тоже разная)
}