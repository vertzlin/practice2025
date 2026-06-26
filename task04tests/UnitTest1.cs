using task04;
using Xunit;

namespace task04tests;

public class SpaceshipTests
{
    // тест 1: проверяем характеристики крейсера
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        // создаём крейсер через интерфейс
        ISpaceship cruiser = new Cruiser();
        
        // проверяем скорость и мощность
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    // тест 2: проверяем характеристики истребителя
    [Fact]
    public void Fighter_ShouldHaveCorrectStats()
    {
        ISpaceship fighter = new Fighter();
        
        Assert.Equal(100, fighter.Speed);
        Assert.Equal(30, fighter.FirePower);
    }

    // тест 3: истребитель должен быть быстрее крейсера
    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        
        // проверяем, что скорость истребителя больше
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    // тест 4: крейсер мощнее истребителя
    [Fact]
    public void Cruiser_ShouldBeMorePowerfulThanFighter()
    {
        var cruiser = new Cruiser();
        var fighter = new Fighter();
        
        Assert.True(cruiser.FirePower > fighter.FirePower);
    }

    // тест 5: движение вперёд увеличивает позицию
    [Fact]
    public void MoveForward_ShouldIncreasePosition()
    {
        var cruiser = new Cruiser();
        int startPos = cruiser.GetPosition();
        
        // двигаемся один раз
        cruiser.MoveForward();
        int endPos = cruiser.GetPosition();
        
        // позиция должна увеличиться на скорость
        Assert.Equal(startPos + cruiser.Speed, endPos);
    }

    // тест 6: поворот изменяет угол
    [Fact]
    public void Rotate_ShouldChangeAngle()
    {
        var fighter = new Fighter();
        int startAngle = fighter.GetAngle();
        
        // поворачиваем на 45 градусов
        fighter.Rotate(45);
        int endAngle = fighter.GetAngle();
        
        Assert.Equal(startAngle + 45, endAngle);
    }

    // тест 7: поворот на 360 градусов возвращает в 0
    [Fact]
    public void Rotate_FullCircle_ReturnsToZero()
    {
        var cruiser = new Cruiser();
        
        cruiser.Rotate(360);
        
        Assert.Equal(0, cruiser.GetAngle());
    }

    // тест 8: отрицательный угол работает правильно
    [Fact]
    public void Rotate_NegativeAngle_WorksCorrectly()
    {
        var fighter = new Fighter();
        
        fighter.Rotate(-45);
        
        // -45 градусов = 315 градусов
        Assert.Equal(315, fighter.GetAngle());
    }

    // тест 9: проверяем, что крейсер реализует интерфейс
    [Fact]
    public void Cruiser_ImplementsISpaceship()
    {
        var cruiser = new Cruiser();
        
        // проверяем, что объект можно привести к интерфейсу
        Assert.IsAssignableFrom<ISpaceship>(cruiser);
    }

    // тест 10: истребитель тоже реализует интерфейс
    [Fact]
    public void Fighter_ImplementsISpaceship()
    {
        var fighter = new Fighter();
        
        Assert.IsAssignableFrom<ISpaceship>(fighter);
    }

    // тест 11: полиморфизм - работа через интерфейс
    [Fact]
    public void Polymorphism_ShouldWorkThroughInterface()
    {
        // оба объекта хранятся как ISpaceship
        ISpaceship ship1 = new Cruiser();
        ISpaceship ship2 = new Fighter();
        
        // характеристики должны отличаться
        Assert.NotEqual(ship1.Speed, ship2.Speed);
        Assert.NotEqual(ship1.FirePower, ship2.FirePower);
    }

    // тест 12: проверяем, что выстрел не падает с ошибкой
    [Fact]
    public void Fire_ShouldNotThrowException()
    {
        ISpaceship cruiser = new Cruiser();
        ISpaceship fighter = new Fighter();
        
        // просто проверяем, что методы не выбрасывают исключения
        var ex = Record.Exception(() => cruiser.Fire());
        Assert.Null(ex);
        
        ex = Record.Exception(() => fighter.Fire());
        Assert.Null(ex);
    }
}