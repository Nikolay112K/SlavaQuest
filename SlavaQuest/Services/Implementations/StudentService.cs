using SlavaQuest.Db;
using SlavaQuest.Models;
using SlavaQuest.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SlavaQuest.Services.Implementations
{
    public class StudentService : IStudenService
    {
        private IFakeDbService _studentsRepository = null;
        public StudentService(IFakeDbService studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        public void AddStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.Name))
            {
                throw new Exception("Student name is empty");
            }

            if (student.Name.Length > 15)
            {
                throw new Exception("Length of name bigger then 15 symbol's");
            }

            if (student.Age < 15 && student.Age > 65)
            {
                throw new Exception("Incorrect age");
            }

            student.Id = Guid.NewGuid();
            _studentsRepository.GetDataBase().Add(student);
        }

        public void DeleteAllStudents()
        {
            _studentsRepository = null;
        }

        public void DeleteStudent(Guid id)
        {
            _studentsRepository.GetDataBase().Remove(ValidateStudentId(id));
        }

        public Student GetStudent(Guid id)
        {
            Student result = ValidateStudentId(id);

            return result;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentsRepository.GetDataBase();
        }

        public Student UpdateStudent(Guid id, byte age = 0, string name = "")
        {
            Student student = _studentsRepository.GetDataBase().Find(s => s.Id == id);

            if (student == null)
            {
                throw new Exception("Student is not found");
            }

            if (age != 0)
            {
                student.Age = age;
            }

            if (name != "")
            {
                student.Name = name;
            }

            return student;
        }

        private Student ValidateStudentId(Guid id)
        {
            Student student = _studentsRepository.GetDataBase().Find(s => s.Id == id);

            if (student == null)
            {
                throw new Exception($"Student with current id: {id} not found");
            }

            return student;
        }
    }
}
