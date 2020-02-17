using SlavaQuest.Models;
using System;
using System.Collections.Generic;

namespace SlavaQuest.Services.Interfaces
{
    public interface IStudenService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(Guid id);
        void AddStudent(Student student);
        Student UpdateStudent(Guid id, byte age = 0, string name = "");
        void DeleteStudent(Guid id);
        void DeleteAllStudents();
    }
}
