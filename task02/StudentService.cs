using System;
using System.Collections.Generic;
using System.Linq;

namespace task02;

public class StudentService
{
    private readonly List<Student> _students;

    public StudentService(List<Student> students)
    {
        _students = students;
    }

    // 1. Получить студентов факультета
    public IEnumerable<Student> GetStudentsByFaculty(string faculty)
    {
        // через LINQ фильтруем по факультету
        var result = from s in _students
                     where s.Faculty == faculty
                     select s;
        return result;
    }

    // 2. Студенты со средним баллом >= заданного
    public IEnumerable<Student> GetStudentsWithMinAverageGrade(double minAverageGrade)
    {
        // проверяем, что есть оценки, и среднее больше порога
        return _students.Where(s => s.Grades.Count > 0 && s.Grades.Average() >= minAverageGrade);
    }

    // 3. Сортировка по имени
    public IEnumerable<Student> GetStudentsOrderedByName()
    {
        // обычная сортировка по алфавиту
        return _students.OrderBy(s => s.Name);
    }

    // 4. Группировка по факультетам
    public ILookup<string, Student> GroupStudentsByFaculty()
    {
        // ToLookup создаёт группы, где ключ - факультет
        return _students.ToLookup(s => s.Faculty);
    }

    // 5. Факультет с самым высоким средним баллом
    public string GetFacultyWithHighestAverageGrade()
    {
        // если студентов нет - возвращаем пустую строку
        if (_students.Count == 0)
            return "";

        // сначала группируем по факультету, считаем средний балл каждого
        var facultyAverages = _students
            .GroupBy(s => s.Faculty)
            .Select(g => new 
            { 
                FacultyName = g.Key, 
                AvgGrade = g.Average(s => s.Grades.Count > 0 ? s.Grades.Average() : 0) 
            });

        // сортируем по убыванию и берём первый
        var best = facultyAverages.OrderByDescending(x => x.AvgGrade).First();
        return best.FacultyName;
    }
}