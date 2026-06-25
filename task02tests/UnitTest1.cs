using task02;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace task02tests;

public class StudentServiceTests
{
    private List<Student> _students;
    private StudentService _service;

    // конструктор - тут создаём тестовые данные
    public StudentServiceTests()
    {
        _students = new List<Student>
        {
            new Student 
            { 
                Name = "Иван", 
                Faculty = "ФИТ", 
                Grades = new List<int> { 5, 4, 5 } 
            },
            new Student 
            { 
                Name = "Анна", 
                Faculty = "ФИТ", 
                Grades = new List<int> { 3, 4, 3 } 
            },
            new Student 
            { 
                Name = "Петр", 
                Faculty = "МО", 
                Grades = new List<int> { 5, 5, 5 } 
            },
            new Student 
            { 
                Name = "Мария", 
                Faculty = "МО", 
                Grades = new List<int> { 4, 4, 4 } 
            },
            new Student 
            { 
                Name = "Сергей", 
                Faculty = "ФИТ", 
                Grades = new List<int> { 2, 3, 2 } 
            }
        };
        _service = new StudentService(_students);
    }

    // Тест 1: фильтрация по факультету
    [Fact]
    public void GetStudentsByFaculty_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsByFaculty("ФИТ").ToList();
        
        // на ФИТ должно быть 3 студента
        Assert.Equal(3, result.Count);
        
        // проверяем, что все с факультета ФИТ
        foreach (var s in result)
        {
            Assert.Equal("ФИТ", s.Faculty);
        }
    }

    // Тест 2: если факультета нет - пустой список
    [Fact]
    public void GetStudentsByFaculty_NoStudents_ReturnsEmpty()
    {
        var result = _service.GetStudentsByFaculty("Юриспруденция").ToList();
        Assert.Empty(result);
    }

    // Тест 3: студенты со средним баллом >= 4
    [Fact]
    public void GetStudentsWithMinAverageGrade_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsWithMinAverageGrade(4.0).ToList();
        
        // должны быть Иван (4.67), Петр (5), Мария (4)
        Assert.Equal(3, result.Count);
        
        // проверяем имена
        var names = result.Select(s => s.Name).ToList();
        Assert.Contains("Иван", names);
        Assert.Contains("Петр", names);
        Assert.Contains("Мария", names);
    }

    // Тест 4: порог слишком высокий - никого нет
    [Fact]
    public void GetStudentsWithMinAverageGrade_NoStudents_ReturnsEmpty()
    {
        var result = _service.GetStudentsWithMinAverageGrade(5.5).ToList();
        Assert.Empty(result);
    }

    // Тест 5: сортировка по имени
    [Fact]
    public void GetStudentsOrderedByName_ReturnsSortedStudents()
    {
        var result = _service.GetStudentsOrderedByName().ToList();
        
        // по алфавиту: Анна, Иван, Мария, Петр, Сергей
        Assert.Equal("Анна", result[0].Name);
        Assert.Equal("Иван", result[1].Name);
        Assert.Equal("Мария", result[2].Name);
        Assert.Equal("Петр", result[3].Name);
        Assert.Equal("Сергей", result[4].Name);
    }

    // Тест 6: группировка работает
    [Fact]
    public void GroupStudentsByFaculty_ReturnsCorrectGroups()
    {
        var groups = _service.GroupStudentsByFaculty();
        
        // должно быть 2 группы
        Assert.Equal(2, groups.Count);
        
        // на ФИТ 3 студента
        Assert.Equal(3, groups["ФИТ"].Count());
        
        // на Экономике 2 студента
        Assert.Equal(2, groups["МО"].Count());
    }

    // Тест 7: факультет с лучшим средним баллом
    [Fact]
    public void GetFacultyWithHighestAverageGrade_ReturnsCorrectFaculty()
    {
        var result = _service.GetFacultyWithHighestAverageGrade();
        Assert.Equal("МО", result);
    }

    // Тест 8: если список пустой
    [Fact]
    public void GetFacultyWithHighestAverageGrade_EmptyList_ReturnsEmptyString()
    {
        var emptyService = new StudentService(new List<Student>());
        var result = emptyService.GetFacultyWithHighestAverageGrade();
        Assert.Equal("", result);
    }
}